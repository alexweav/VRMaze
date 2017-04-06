import numpy as np
from graph import *

class TraverseMazeEnvironment():

        def __init__(self, size):
            self.size = size

        def reset(self):
            self.graph = Graph(self.size, self.size)
            self.graph.connect_maze()
            self.current_node = (0, 0)
            self.exploration_buffer = np.zeros((self.size, self.size))
            self.exploration_buffer[(0, 0)] = self.graph.get_connection_code(self.current_node) + 16
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
                if self.exploration_buffer[target_node] == 0:
                    reward = 25.0
                    next_node = target_node
                else:
                    reward = 0.25
                    next_node = target_node
            else:
                reward = -2.5
                next_node = self.current_node
            self.exploration_buffer[self.current_node] -= 16
            self.exploration_buffer[next_node] = self.graph.get_connection_code(next_node)
            self.exploration_buffer[next_node] += 16
            self.current_node = next_node
            return self.create_observation(), reward
                    

        def create_observation(self):
            return self.exploration_buffer.reshape(1, np.prod(self.exploration_buffer.shape))

