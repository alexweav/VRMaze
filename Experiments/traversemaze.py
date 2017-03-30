#A reinforcement learning agent learns to move around in a generated maze

import numpy as np

from graph import *
from neuralnet import *

num_games = 1
steps_per_game = 100

def main():
    #Construct the model
    action_dim = 4
    architecture = [102, 75, action_dim]
    net = NeuralNet(architecture)

    for game in range(num_games):
        #Create a new maze and set up initial observation
        graph = Graph(10, 10)
        graph.connect_maze()
        current_node = (0, 0)
        exploration_buffer = np.zeros((10, 10))
        exploration_buffer[(0, 0)] = graph.get_connection_code(current_node)
        observation = create_observation(exploration_buffer, current_node)

        #Data stored at every game step:
        observations = [] #The observation at each game step
        hidden_activations = [] #The hidden layer activations of the net
        d_log_probs = [] #Derivative of loss function
        rewards = [] #Reward gained
        total_reward = 0.0
        for stepnum in range(steps_per_game):
            #Get action from network
            probabilities, hidden_activation = net.eval(observation)
            choice = net.make_choice(probabilities)
            choice_vector = np.zeros_like(probabilities)
            choice_vector[(0, choice)] = 1
            #Perform the action
            current_node, reward = step(graph, current_node, choice)
            #Cache data
            observations.append(observation)
            hidden_activations.append(hidden_activation)
            d_log_probs.append(choice_vector - probabilities)
            rewards.append(reward)
            #Set up next observation
            exploration_buffer[current_node] = graph.get_connection_code(current_node)
            observation = create_observation(exploration_buffer, current_node)
            print(choice, reward)
            print(exploration_buffer)
        observations = np.vstack(observations)
        d_log_probs = np.vstack(d_log_probs)
        rewards = np.vstack(rewards)

        #Accumulate rewards over time and normalize
        accumulated_rewards = net.accumulate_reward(rewards)
        accumulated_rewards -= np.mean(accumulated_rewards)
        accumulated_rewards /= np.std(accumulated_rewards)

        #Modulate gradient by normalized, accumulated rewards
        d_log_probs *= accumulated_rewards/accumulated_rewards.shape[0]

#A single game observation is a pair (exploration buffer, current node)
#Represented in a row vector of integers
def create_observation(exploration_buffer, current_node):
    row, col = current_node
    expl = exploration_buffer.reshape(1, np.prod(exploration_buffer.shape))
    node = np.array([[row, col]])
    return np.concatenate((expl, node), axis=1)

#Performs an action in the game
#Returns a pair (new_current_node, reward)
def step(graph, current_node, choice):
    target_node = current_node
    row, col = current_node
    if choice == 0: target_node = (row-1, col) #up
    if choice == 1: target_node = (row+1, col) #down
    if choice == 2: target_node = (row, col-1) #left
    if choice == 3: target_node = (row, col+1) #right
    if graph.connected(current_node, target_node):
        return target_node, 1.0
    else:
        return current_node, -1.0

main()
