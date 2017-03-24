#Basic grid graph class
class Graph:

    def __init__(self, rows, cols):
        self.data = {}
        for row in range(rows):
            for col in range(cols):
                self.add_node((row, col))
        self.rows = rows
        self.cols = cols
    
    def add_node(self, item):
        self.data[item] = []

    def add_edge(self, item1, item2):
        self.data[item1] += [item2]

    def contains(self, item1):
        return item1 in self.data

    def connected(self, item1, item2):
        return item2 in self.data[item1]

    def connect_grid(self):
        for node in self.data:
            x, y = node
            if (x > 0): self.add_edge((x, y), (x-1, y))
            if (y > 0): self.add_edge((x, y), (x, y-1))
            if (x < self.rows-1): self.add_edge((x, y), (x+1, y))
            if (y < self.cols-1): self.add_edge((x, y), (x, y+1))

    def connect_maze(self):
        pass

    def write(self):
        for row in range(self.rows):
            for col in range(self.cols):
                if self.contains((row, col)): print('O', end='')
                if self.connected((row, col), (row, col+1)): print('--', end='') 
                else: print('  ', end='')
            print()
            for col in range(self.cols):
                if self.connected((row, col), (row+1, col)): print('|', end='')
                else: print(' ', end='')
                print('  ', end='')
            print()

x = Graph(10, 10)
x.connect_grid()
x.write()
