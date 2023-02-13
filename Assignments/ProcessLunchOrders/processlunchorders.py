#!/bin/python
import sys


from PyQt6 import uic
from PyQt6.QtWidgets import (
    QApplication,
    QWidget,
    QPushButton,
    QRadioButton,
    QTextEdit,
    QCheckBox,
    QGroupBox,
)


class ProcessLunchOrders(QWidget):
    def __init__(self):
        super().__init__()

        # Some constants
        self.mainPrices = [6.95, 5.95, 4.95]  # All prices
        self.addOnPrices = [0.75, 0.50, 0.25]

        # load ui file
        uic.loadUi("lunchOrders.ui", self)

        # Connect controls
        exitButton = self.findChild(QPushButton, "exitButton")
        exitButton.clicked.connect(self.cleanExit)

        placeButton = self.findChild(QPushButton, "placeButton")
        placeButton.clicked.connect(self.placeOrder)

        # Connect inputs and outputs
        self.mainSelection = [
            self.findChild(QRadioButton, "hamburgerButton"),
            self.findChild(QRadioButton, "pizzaButton"),
            self.findChild(QRadioButton, "saladButton"),
        ]

        self.addOnSeletion = [
            self.findChild(QCheckBox, "LettuceCheckBox"),
            self.findChild(QCheckBox, "KetchupCheckBox"),
            self.findChild(QCheckBox, "FriesCheckBox"),
        ]

        self.subtotalBox = self.findChild(QTextEdit, "subtotalBox")

        # This is needed because the label above the addons must be updated when a main course is selected
        for btn in self.mainSelection:
            btn.clicked.connect(
                self.updateLabels
            )  # This connects every element to this label
        self.addOnLabel = self.findChild(QGroupBox, "AddOnItemsBox")
        self.addOnLabelStr = (
            "Add-on items ($%s/each)"  # use this string every time when formatting
        )
        self.addOnLabel.setTitle(self.addOnLabelStr % 0.75)  # Update the string

    def placeOrder(self):
        # Quickly find what radio button is pushed

        # Price is the sum of everything selected
        price = self.getSum(self.mainPrices, self.mainSelection)
        addOnPrice = self.getSum(self.addOnPrices, self.addOnSeletion)

        self.subtotalBox.setText(f"${price + addOnPrice:.2f}")

    def updateLabels(self):
        """Updates any labels needed"""
        self.addOnLabel.setTitle(
            self.addOnLabelStr % self.getSum(self.addOnPrices, self.mainSelection)
        )

    def getSum(self, vals, sel):
        """Zipper merges two lists and finds the sum between"""
        return sum([p for i, p in enumerate(vals) if self.getSelected(sel)[i]])

    def getSelected(self, ops):
        """Returns the selected elements in list."""
        return [btn.isChecked() for btn in ops]

    def cleanExit(self):
        sys.exit(app.exec())


if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = ProcessLunchOrders()
    widget.show()
    sys.exit(app.exec())
