def isEven(num):
    return num % 2 == 0


def steps(number):
    if number < 1:
        raise ValueError("Only positive integers are allowed")

    count = 0
    while number > 1:
        if isEven(number):
            number //= 2
        else:
            number = 3 * number + 1
        count += 1
    return count
