import numpy as np
from graph import *

class TraverseMazeEnvironment():

        def __init__(self, size):
            self.size = size

        #Observation is a 3d tensor 6 by Size by Size
        #Observation[0,j,k]=1 -> cell j, k has a connection up
        #Observation[1,j,k]=1 -> cell j, k has a connection down
        #Observation[2,j,k]=1 -> cell j, k has a connection left
        #Observation[3,j,k]=1 -> cell j, k has a connection right
        #Observation[4,j,k]=1 -> cell j, k has known state
        #Observation[5,j,k]=1 -> agent is in cell j, k
        def reset(self):
            self.graph = Graph(self.size, self.size)
            self.graph.connect_maze()
            self.current_node = (0, 0)
            #self.exploration_buffer = np.zeros((self.size, self.size))
            #self.exploration_buffer[(0, 0)] = self.graph.get_connection_code(self.current_node) + 16
            self.exploration_buffer = np.zeros((6, self.size, self.size))
            code = self.graph.get_connection_code(self.current_node)
            row, col = self.current_node
            self.exploration_buffer[(0, row, col)] = 1 if code & 1 > 0 else 0
            self.exploration_buffer[(1, row, col)] = 1 if code & 2 > 0 else 0
            self.exploration_buffer[(2, row, col)] = 1 if code & 4 > 0 else 0
            self.exploration_buffer[(3, row, col)] = 1 if code & 8 > 0 else 0
            self.exploration_buffer[(4, row, col)] = 1
            self.exploration_buffer[(5, row, col)] = 1
            return self.create_observation()

        #Returns observation, reward
        def step(self, action):
            target_node = self.current_node
            row, col = self.current_node
            if action == 0: target_node = (row-1, col)
            if action == 1: target_node = (row+1, col)
            if action == 2: target_node = (row, col-1)
            if action == 3: target_node = (row, col+1)
            reward = 0.0
            next_node = self.current_node
            if self.graph.connected(self.current_node, target_node):
                reward = 1.0
                next_node = target_node
                """
                if self.exploration_buffer[(5, target_node[0], target_node[1])] == 0:
                    reward = np.count_nonzero(self.exploration_buffer[4])
                    next_node = target_node
                else:
                    reward = 0.0
                    next_node = target_node
                """
            else:
                reward = -1.0
                next_node = self.current_node
            self.exploration_buffer[(5, self.current_node[0], self.current_node[1])] = 0
            code = self.graph.get_connection_code(next_node)
            self.exploration_buffer[(0, next_node[0], next_node[1])] = 1 if code & 1 > 0 else 0
            self.exploration_buffer[(1, next_node[0], next_node[1])] = 1 if code & 2 > 0 else 0
            self.exploration_buffer[(2, next_node[0], next_node[1])] = 1 if code & 4 > 0 else 0
            self.exploration_buffer[(3, next_node[0], next_node[1])] = 1 if code & 8 > 0 else 0
            self.exploration_buffer[(4, next_node[0], next_node[1])] = 1

            self.exploration_buffer[(5, next_node[0], next_node[1])] = 1
            self.current_node = next_node
            return self.create_observation(), reward
                    

        def create_observation(self):
            return self.exploration_buffer.reshape(1, np.prod(self.exploration_buffer.shape))

