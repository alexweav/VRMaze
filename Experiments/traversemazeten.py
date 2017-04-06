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

main()
