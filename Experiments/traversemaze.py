#A reinforcement learning agent learns to move around in a generated maze

import numpy as np

from graph import *
from neuralnet import *

num_games = 1
steps_per_game = 100

def main():
    #Create a new 10x10 maze
    action_dim = 4
    architecture = [102, 75, action_dim]
    net = NeuralNet(architecture)
    for game in range(num_games):
        graph = Graph(10, 10)
        graph.connect_maze()
        current_node = (0, 0)
        exploration_buffer = np.zeros((10, 10))
        exploration_buffer[(0, 0)] = graph.get_connection_code(current_node)
        observation = create_observation(exploration_buffer, current_node)
        for stepnum in range(steps_per_game):
            probabilities, _ = net.eval(observation)
            choice = net.make_choice(probabilities)
            current_node, reward = step(graph, current_node, choice)
            exploration_buffer[current_node] = graph.get_connection_code(current_node)
            print(choice, reward)
            print(exploration_buffer)
            input()

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
        return target_node, 1
    else:
        return current_node, -1

main()
