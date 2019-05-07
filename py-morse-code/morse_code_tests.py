import unittest

from morse_code import MorseCode


class MorseCodeTests(unittest.TestCase):

    def test_convert_to_returns_empty_for_empty(self):
        value = ""
        actual = MorseCode.convert_to(value)
        self.assertEqual("", actual)

    def test_convert_to_returns_dot_dash_for_a(self):
        value = "a"
        actual = MorseCode.convert_to(value)
        self.assertEqual(".-", actual)

    def test_convert_to_returns_result_for_made_it(self):
        value = "Made it"
        actual = MorseCode.convert_to(value)
        self.assertEqual("-- .- -.. .   .. -", actual)

    def test_convert_from_returns_result_for_a(self):
        value = ".-"
        actual = MorseCode.convert_from(value)
        self.assertEqual("a", actual)

    def test_convert_from_returns_result_for_made_it(self):
        value = "-- .- -.. .   .. -"
        actual = MorseCode.convert_from(value)
        self.assertEqual("made it", actual)


if __name__ == "__main__":
    unittest.main()
