# This Python file uses the following encoding: utf-8
import sys


from PyQt6 import uic
from PyQt6.QtWidgets import QApplication, QWidget


class ProcessLunchOrders(QWidget):
    def __init__(self):
        QWidget.__init__(self)

        # load ui file
        uic.loadUi("lunchOrders.ui", self)

        # self.window.show()

        # sys.exit(app.exec())


if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = ProcessLunchOrders()
    widget.show()
    sys.exit(app.exec())
