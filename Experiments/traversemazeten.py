#traversemaze.py in tensorflow
import numpy as np
import tensorflow as tf

from graph import *
from env_traversemaze import *

num_games = 1
steps_per_game = 10
maze_size = 5
D = maze_size*maze_size
print_every = 100

H = 500
learning_rate = 1e-3
gamma = 0.99

def main():
    env = TraverseMazeEnvironment(maze_size)
    model = Model()
    init = tf.initialize_all_variables()
    with tf.Session() as sess:
        sess.run(init)
        for game in range(num_games):
            xs, hs, dlogps, drs, ys, tfps = [], [], [], [], [], []
            running_rewarad = None
            reward_sum = 0.0
            observation = env.reset()
            grad_buffer = sess.run(model.tvars)
            for ix, grad in enumerate(grad_buffer):
                grad_buffer[ix] = grad * 0
            for step in range(steps_per_game):
                tfprob = sess.run(model.probability, feed_dict={model.observations: observation})
                choice = make_choice(tfprob)
                xs.append(observation)
                choice_vector = np.zeros_like(tfprob)
                choice_vector[(0, choice)] = 1
                ys.append(choice_vector)
                observation, reward = env.step(choice)
                reward_sum += reward
                drs.append(reward)
                print(observation)
                print(reward)

def discount_rewards(rewards):
    discounted_rewards = np.zeros_like(rewards)
    accumulator = 0.0
    for i in reversed(range(np.prod(rewards.shape))):
        accumulator = accumulator * gamma + rewards[i]
        discounted_rewards[i] = accumulator
    return discounted_rewards

def make_choice(probabilities):
    return np.random.choice(np.arange(np.prod(probabilities.shape)), p=probabilities.ravel())

class Model():

    def __init__(self):
        tf.reset_default_graph()
        self.observations = tf.placeholder(tf.float32, [None, D], name="input_x")
        self.W1 = tf.get_variable("W1", shape=[D, H], initializer=tf.contrib.layers.xavier_initializer())
        self.layer1 = tf.nn.relu(tf.matmul(self.observations, self.W1))
        self.W2 = tf.get_variable("W2", shape=[H, 4], initializer=tf.contrib.layers.xavier_initializer())
        self.score = tf.matmul(self.layer1, self.W2)
        self.probability = tf.nn.softmax(self.score)

        self.tvars = tf.trainable_variables()
        self.input_y = tf.placeholder(tf.float32, [None, 4], name="input_y")
        self.advantages = tf.placeholder(tf.float32, name="reward_signal")

        self.loglik = tf.log(self.input_y*(self.input_y - self.probability)+(1-self.input_y)*(self.input_y + self.probability))
        self.loss = -tf.reduce_mean(self.loglik*self.advantages)
        self.new_grads = tf.gradients(self.loss, self.tvars)

        self.adam = tf.train.AdamOptimizer(learning_rate=learning_rate)
        self.W1_grad = tf.placeholder(tf.float32, name="batch_grad1")
        self.W2_grad = tf.placeholder(tf.float32, name="batch_grad2")
        self.batch_grad = [self.W1_grad, self.W2_grad]
        self.update_grads = self.adam.apply_gradients(zip(self.batch_grad, self.tvars))




main()
