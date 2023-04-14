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


class Password(QWidget):
    def __init__(self):
        super().__init__()

        # load ui file
        uic.loadUi("app.ui", self)

        # Connect controls
        self.showBtn = self.findChild(QPushButton, "showMeBtn")
        self.showBtn.clicked.connect(self.showMe)

        self.passwordBox = self.findChild(QLineEdit, "passwordBox")
        self.passwordBox.setEchoMode(QLineEdit.EchoMode.Password)

        self.isShown = False

    def showMe(self):
        if(self.isShown):
            self.passwordBox.setEchoMode(QLineEdit.EchoMode.Password)
            self.showBtn.setText("Show Me")
        else:
            self.passwordBox.setEchoMode(QLineEdit.EchoMode.Normal)
            self.showBtn.setText("Hide!")

        self.isShown = not self.isShown
        




if __name__ == "__main__":
    app = QApplication(sys.argv)
    widget = Password()
    widget.show()
    sys.exit(app.exec())
