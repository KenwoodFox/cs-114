#!/bin/python
import sys


from PyQt6 import uic
from PyQt6.QtCore import QDate
from PyQt6.QtWidgets import (
    QApplication,
    QWidget,
    QPushButton,
    QRadioButton,
    QTextEdit,
    QCheckBox,
    QGroupBox,
    QDateEdit,
    QLineEdit,
)


class AccumulateTestScore(QWidget):
    def __init__(self):
        super().__init__()

        # load ui file
        uic.loadUi("app.ui", self)

        # Connect controls
        exitButton = self.findChild(QPushButton, "exitButton")
        exitButton.clicked.connect(self.cleanExit)

        calculateButton = self.findChild(QPushButton, "addBtn")
        calculateButton.clicked.connect(self.add)

        self.scoreBox = self.findChild(QLineEdit, "ScoreBox")
        self.scoreTotal = self.findChild(QLineEdit, "ScoreTotal")
        self.scoreCount = self.findChild(QLineEdit, "ScoreCount")
        self.scoreAvg = self.findChild(QLineEdit, "Average")

        self.data = []

    def add(self):
        try:
            self.data.append(int(self.scoreBox.text()))
        except ZeroDivisionError:
            pass

        self.scoreTotal.setText(f"{sum(self.data)}")
        self.scoreCount.setText(f"{len(self.data)}")
        self.scoreAvg.setText(f"{sum(self.data) / len(self.data):.0f}")

    def duration(self, a, b):
        return a.daysTo(b)

    def cleanExit(self):
        sys.exit(app.exec())


if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = AccumulateTestScore()
    widget.show()
    sys.exit(app.exec())
