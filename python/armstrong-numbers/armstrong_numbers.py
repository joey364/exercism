def is_armstrong_number(number):
    digit_count = len(str(number))
    tmp = number
    sum = 0

    while tmp > 0:
        rem = tmp % 10
        sum = sum + (rem**digit_count)
        tmp //= 10

    if number == sum:
        return True
    return False
