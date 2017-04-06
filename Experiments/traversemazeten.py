#traversemaze.py in tensorflow
import numpy as np
import tensorflow as tf

from graph import *
from env_traversemaze import *

num_games = 1
steps_per_game = 10
maze_size = 5
print_every = 100

H = 1000
learning_rate = 1e-3
gamma = 0.99

def main():
    env = TraverseMazeEnvironment(maze_size)
    for game in range(num_games):
        observation = env.reset()
        for step in range(steps_per_game):
            observation, reward = env.step(np.random.randint(0, 4))
            print(observation)
            print(reward)

def build_model():
    D = maze_size*maze_size
    tf.reset_default_graph()
    observations = tf.placeholder(tf.float32, [None, D], name="input_x")
    W1 = tf.get_variable("W1", shape=[D, H], initializer=tf.conrib.layers.xavier_initializer())
    layer1 = tf.nn.relu(tf.matmul(observations, W1))
    W2 = tf.get_variable("W2", shape=[H, 1], initializer=tf.contrib.layers.xavier_initializer())
    score = tf.matmul(layer1, W2)
    probability = tf.nn.softmax(score)

    tvars = tf.trainable_variables()
    input_y = tf.placeholder(tf.float32, [None, 1], name="input_y")
    advantages = tf.placeholder(tf.float32, name="reward_signal")

main()
