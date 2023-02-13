# This Python file uses the following encoding: utf-8
import sys


from PyQt6 import uic
from PyQt6.QtWidgets import (
    QApplication,
    QWidget,
    QPushButton,
    QRadioButton,
    QTextEdit,
    QCheckBox,
)


class ProcessLunchOrders(QWidget):
    def __init__(self):
        super().__init__()

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

    def placeOrder(self):
        # Quickly find what radio button is pushed
        prices = [6.95, 5.95, 4.95]  # All prices
        # Price is the sum of everything selected
        price = sum(
            [p for i, p in enumerate(prices) if self.getSelected(self.mainSelection)[i]]
        )

        addOnPrices = [0.75, 0.50, 0.25]  # All add on prices
        addOnPrice = sum(
            [
                p
                for i, p in enumerate(addOnPrices)
                if self.getSelected(self.addOnSeletion)[i]
            ]
        )

        self.subtotalBox.setText(f"${price + addOnPrice:.2f}")

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
