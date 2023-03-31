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
)


class MyApp(QWidget):
    def __init__(self):
        super().__init__()

        # load ui file
        uic.loadUi("app.ui", self)

        # Connect controls
        exitButton = self.findChild(QPushButton, "exitButton")
        exitButton.clicked.connect(self.cleanExit)

        calculateButton = self.findChild(QPushButton, "calculateButton")
        calculateButton.clicked.connect(self.calculate)

        self.arrivalDate = self.findChild(QDateEdit, "arrivalDate")
        self.arrivalDate.setDate(QDate(2023, 3, 10))
        self.departureDate = self.findChild(QDateEdit, "departureDate")
        self.departureDate.setDate(QDate(2023, 3, 14))

        self.numNights = self.findChild(QTextEdit, "numberNights")
        self.totalPrice = self.findChild(QTextEdit, "totalPrice")
        self.avgPrice = self.findChild(QTextEdit, "avgPricePerNight")

        # Constants
        self.pricePerNight = 120.0
        self.extraPrice = 150.0

    def calculate(self):
        n_nights = self.duration(self.arrivalDate.date(), self.departureDate.date())
        price = 0
        for i in range(n_nights):
            day = self.arrivalDate.date().dayOfWeek() + i % 7
            print(day)
            if day == 5 or day == 6:
                price += self.extraPrice
            else:
                price += self.pricePerNight

        self.numNights.setText(str(n_nights))

        self.totalPrice.setText(f"${price:.2f}")
        self.avgPrice.setText(f"${price/n_nights:.2f}")

    def duration(self, a, b):
        return a.daysTo(b)

    def cleanExit(self):
        sys.exit(app.exec())


if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = MyApp()
    widget.show()
    sys.exit(app.exec())
