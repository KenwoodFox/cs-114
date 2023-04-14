#!/bin/python
import sys


from PyQt6 import QtGui, QtWidgets, uic
from PyQt6.QtCore import Qt
from PyQt6.QtWidgets import QApplication
from PyQt6.QtGui import QPainter, QBrush, QColor, QPen


class EventHandling(QtWidgets.QMainWindow):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Draw With Mouse")

        self.label = QtWidgets.QLabel()
        canvas = QtGui.QPixmap(700, 400)
        canvas.fill(Qt.GlobalColor.white)
        self.label.setPixmap(canvas)
        self.setCentralWidget(self.label)

        self.last_x, self.last_y = None, None

    def mouseMoveEvent(self, e):
        if self.last_x is None:  # First event.
            self.last_x = e.position().x()
            self.last_y = e.position().y()
            return  # Ignore the first time.

        canvas = self.label.pixmap()

        # Create painter
        painter = QtGui.QPainter(canvas)

        # Create a pen
        pen = QPen()  # creates a default pen
        pen.setWidth(10)
        pen.setBrush(QColor(0, 0, 255))

        painter.setPen(pen)
        painter.drawLine(
            int(self.last_x),
            int(self.last_y),
            int(e.position().x()),
            int(e.position().y()),
        )
        painter.end()
        self.label.setPixmap(canvas)

        # Update the origin for next time.
        self.last_x = e.position().x()
        self.last_y = e.position().y()

    def mouseReleaseEvent(self, e):
        self.last_x = None
        self.last_y = None

    def cleanExit(self):
        sys.exit(app.exec())


if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = EventHandling()
    widget.show()
    sys.exit(app.exec())
