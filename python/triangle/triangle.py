def assertIsTriangle(sides):
    return sum(sorted(sides)[:2]) >= sorted(sides)[2] and all(x > 0 for x in sides)


def equilateral(sides):
    return assertIsTriangle(sides) and sides[0] == sides[1] == sides[2]


def isosceles(sides):
    sides = sorted(sides)
    return (
        assertIsTriangle(sides)
        and sides[0] == sides[1]
        or sides[0] == sides[2]
        or sides[1] == sides[2]
    )


def scalene(sides):
    return assertIsTriangle(sides) and not isosceles(sides)
