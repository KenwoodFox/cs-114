#!/bin/python
import sys


from PyQt6 import QtGui, QtWidgets, uic
from PyQt6.QtCore import Qt
from PyQt6.QtWidgets import QApplication, QPushButton, QLabel
from PyQt6.QtGui import QPainter, QBrush, QColor, QPen


class PaintProgram(QtWidgets.QMainWindow):
    def __init__(self):
        super().__init__()

        # load ui file
        uic.loadUi("app.ui", self)

        # Connect controls
        brushBtn = self.findChild(QPushButton, "setBrushButton")
        brushBtn.clicked.connect(self.setBrush)

        squareBtn = self.findChild(QPushButton, "setSquareButton")
        squareBtn.clicked.connect(self.setSquare)

        self.label = self.findChild(QLabel, "canvasLabel")
        canvas = QtGui.QPixmap(700, 400)
        canvas.fill(Qt.GlobalColor.white)
        self.label.setPixmap(canvas)

        self.last_x, self.last_y = None, None
        self.brush = True

    def setBrush(self):
        self.brush = True

    def setSquare(self):
        self.brush = False

    def mouseMoveEvent(self, e):
        if self.last_x is None:  # First event.
            self.last_x = e.position().x()
            self.last_y = e.position().y()
            return  # Ignore the first time.


        # Create a pen
        if self.brush:
            canvas = self.label.pixmap()

            # Create painter
            painter = QtGui.QPainter(canvas)

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
        if self.brush:
            self.last_x = None
            self.last_y = None
        else:
            canvas = self.label.pixmap()

            # Create painter
            painter = QtGui.QPainter(canvas)

            pen = QPen()  # creates a default pen
            pen.setWidth(10)
            pen.setBrush(QColor(0, 0, 255))

            painter.setPen(pen)
            painter.drawRect(
                int(self.last_x),
                int(self.last_y),
                int(e.position().x()),
                int(e.position().y()),
            )
            painter.end()
            self.label.setPixmap(canvas)

            self.last_x = None
            self.last_y = None

    def cleanExit(self):
        sys.exit(app.exec())


if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = PaintProgram()
    widget.show()
    sys.exit(app.exec())
