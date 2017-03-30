#A reinforcement learning agent learns to move around in a generated maze

import numpy as np

from graph import *
from neuralnet import *

def main():
    #Create a new 10x10 maze
    graph = Graph(10, 10)
    graph.connect_maze()
    current_node = (0, 0)
    exploration_buffer = np.zeros((10, 10))
    exploration_buffer[(0, 0)] = graph.get_connection_code(current_node)
    observation = create_observation(exploration_buffer, current_node)
    action_dim = 4
    architecture = [np.prod(observation.shape), 75, action_dim]
    net = NeuralNet(architecture)
    probabilities, _ = net.eval(observation)
    choice = net.make_choice(probabilities)
    print(probabilities)
    print(choice)

#A single game observation is a pair (exploration buffer, current node)
#Represented in a row vector of integers
def create_observation(exploration_buffer, current_node):
    row, col = current_node
    expl = exploration_buffer.reshape(1, np.prod(exploration_buffer.shape))
    node = np.array([[row, col]])
    return np.concatenate((expl, node), axis=1)




main()
