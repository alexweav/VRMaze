import numpy as np

#Standard n-layer neural network for policy gradients (discrete action space classification)
#ReLU activation, RMSProp updates
class NeuralNet():

    def __init__(self, architecture):
        self.init_model(architecture)
        self.init_rmsprop_cache()

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
        for layer in range(1, len(architecture)):
            self.weights_cache += [np.zeros_like(self.weights[layer])]
            self.biases_cache += [np.zeros_like(self.biases[layer])]

    def sigmoid(x):
        return 1. / (1. + np.exp(-x))

    def relu(x):
        x[x<0] = 0
        return x

architecture = [3, 7, 5]
net = NeuralNet(architecture)
for layer in range(len(architecture)):
    print(architecture[layer])
    print(net.weights[layer])
    print(net.weights_cache[layer])
    print(net.biases[layer])
    print(net.biases_cache[layer])
