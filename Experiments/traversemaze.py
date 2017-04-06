#A reinforcement learning agent learns to move around in a generated maze

import numpy as np

from graph import *
from neuralnet import *
from env_traversemaze import *

num_games = 10000
steps_per_game = 100
maze_size = 5
print_every = 100

def main():
    #Construct the model
    action_dim = 4
    architecture = [maze_size*maze_size, 500, 100, action_dim]
    net = NeuralNet(architecture, 3e-4)

    set_valid = 0
    set_invalid = 0
    set_cells = 0
    set_reward = 0

    for game in range(num_games):
        #Create a new maze and set up initial observation
        env = TraverseMazeEnvironment(maze_size)
        observation = env.reset()
        #Data stored at every game step:
        observations = [] #The observation at each game step
        hidden_activations = [] #The hidden layer activations of the net
        for i in range(len(architecture)-2): #One list for each hidden layer, containing activation at each step
            hidden_activations += [[]]
        d_log_probs = [] #Derivative of loss function
        rewards = [] #Reward gained
        valid_moves = 0
        invalid_moves = 0
        total_reward = 0.0
        for stepnum in range(steps_per_game):
            #Get action from network
            probabilities, hidden_activation = net.eval(observation)
            for i in range(len(hidden_activation)):
                hidden_activations[i].append(hidden_activation[i])
            choice = net.make_choice(probabilities)
            choice_vector = np.zeros_like(probabilities)
            choice_vector[(0, choice)] = 1
            observations.append(observation)
            #Perform the action
            observation, reward = env.step(choice)
            total_reward += reward
            if reward > 0:
                valid_moves += 1
            else:
                invalid_moves += 1
            #Cache data
            d_log_probs.append(probabilities-choice_vector)
            rewards.append(reward)
            #Set up next observation
        observations = np.vstack(observations)
        d_log_probs = np.vstack(d_log_probs)
        for i in range(len(hidden_activations)):
            hidden_activations[i] = np.vstack(hidden_activations[i])
        rewards = np.vstack(rewards)

        #Accumulate rewards over time and normalize
        accumulated_rewards = net.accumulate_reward(rewards)
        accumulated_rewards -= np.mean(accumulated_rewards)
        accumulated_rewards /= np.std(accumulated_rewards)


        #Modulate gradient by normalized, accumulated rewards
        d_log_probs *= accumulated_rewards/accumulated_rewards.shape[0]

        net.backprop(d_log_probs, observations, hidden_activations)
        net.update()

        cells_explored = np.count_nonzero(env.exploration_buffer)
        #print("Game ", game, ", ", valid_moves, " valid moves, ", invalid_moves, "invalid moves, ", cells_explored, "cells explored")
        set_valid += valid_moves
        set_invalid += invalid_moves
        set_cells += cells_explored
        set_reward += total_reward

        if game%print_every == 0:
            print("Avg. valid:", set_valid/float(print_every), "Avg. cells explored", set_cells/float(print_every), "Reward", set_reward/float(print_every))
            set_valid = 0
            set_invalid = 0
            set_cells = 0
            set_reward = 0

main()
