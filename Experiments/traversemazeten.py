#traversemaze.py in tensorflow
import numpy as np
import tensorflow as tf

from graph import *

num_games = 10000
steps_per_game = 100
maze_size = 5
print_every = 100

def main():
    action_dim = 4
    architecture = [maze_size*maze_size+2, 500, action_dim]

main()
