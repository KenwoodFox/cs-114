#!/bin/python
import sys


from PyQt6 import uic
from PyQt6.QtCore import QDate
from PyQt6.QtWidgets import *


class Grocery(QWidget):
    def __init__(self):
        super().__init__()

        # load ui file
        uic.loadUi("app.ui", self)

        # Connect controls
        exitButton = self.findChild(QPushButton, "exitButton")
        exitButton.clicked.connect(self.cleanExit)

        addBtn = self.findChild(QPushButton, "addButton")
        addBtn.clicked.connect(self.add)

        removeButton = self.findChild(QPushButton, "removeButton")
        removeButton.clicked.connect(self.remove)

        clearBtn = self.findChild(QPushButton, "clearButton")
        clearBtn.clicked.connect(self.clear)

        self.listBox = self.findChild(QListWidget, "listWidget")

        self.inputEdit = self.findChild(QLineEdit, "inputEdit")

    def add(self):
        self.listBox.insertItem(0, self.inputEdit.text())
        self.inputEdit.setText("")

    def remove(self):
        for item in self.listBox.selectedItems():
            self.listBox.takeItem(self.listBox.row(item))

    def clear(self):
        self.listBox.clear()

    def cleanExit(self):
        sys.exit(app.exec())


if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = Grocery()
    widget.show()
    sys.exit(app.exec())
