class Node(object):
    def __init__(self, data, parent):
        self.data = data
        self.parent = parent
        self.children = []

    def __str__(self):
        result = self.data

        for c in self.children:
            result += str(c)

        return result

    def add_child(self, obj):
        self.children.append(obj)
