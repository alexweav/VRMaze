import numpy as np

#Standard n-layer neural network for policy gradients (discrete action space classification)
#ReLU activation, RMSProp updates
class NeuralNet():

    #Architecture is a list of ints, describing the number of neurons in each layer
    #architecture[0] is the input dim, architecture[-1] is the output dim
    #Gamma is the reward decay rate
    def __init__(self, architecture, gamma=0.99):
        self.architecture = architecture
        self.init_model(architecture)
        self.init_rmsprop_cache()
        self.gamma = gamma

    def init_model(self, architecture):
        self.weights = [np.empty(shape=(0,0))]
        self.biases = [np.empty(shape=(0, 0))]
        for layer in range(1, len(architecture)):
            W = np.random.randn(architecture[layer-1], architecture[layer]) / np.sqrt(architecture[layer-1])
            b = np.zeros((1, architecture[layer]))
            self.weights += [W]
            self.biases += [b]

    def init_rmsprop_cache(self):
        self.weights_cache = [np.empty(shape=(0,0))]
        self.biases_cache = [np.empty(shape=(0,0))]
        for layer in range(1, len(self.architecture)):
            self.weights_cache += [np.zeros_like(self.weights[layer])]
            self.biases_cache += [np.zeros_like(self.biases[layer])]

    def sigmoid(self, x):
        return 1. / (1. + np.exp(-x))

    def relu(self, x):
        x[x<0] = 0
        return x

    def softmax(self, x):
        ex = np.exp(x)
        return ex / np.sum(ex, axis=1).reshape(-1, 1)

    def eval(self, data):
        layer_in = data
        #Cache internal activation data for future use in backprop
        hidden_activations = [np.empty(shape=(0,0))]
        for layer in range(1, len(self.architecture)-1):
            score = np.dot(layer_in, self.weights[layer]) + self.biases[layer]
            activation = self.relu(score)
            hidden_activations += [activation]
            layer_in = activation
        #Don't perform activation function on final score
        final_scores = np.dot(layer_in, self.weights[-1]) + self.biases[-1]
        probabilities = self.softmax(final_scores)
        return probabilities, hidden_activations

    def make_choice(self, probabilities):
        return np.random.choice(np.arange(np.prod(probabilities.shape)), p=probabilities.ravel())

    def accumulate_reward(self, rewards):
        accumulated_reward = np.zeros_like(rewards)
        accumulator = 0.0
        for i in range(rewards.shape[0]):
            accumulator = self.gamma * accumulator + rewards[i]
            accumulated_reward[i] = accumulator
        return accumulated_reward

    def backprop(self, d_log_probs, observations, hidden_activations):
        pass
