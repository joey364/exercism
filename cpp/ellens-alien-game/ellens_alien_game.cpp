namespace targets {

class Alien {
public:
  Alien(int x, int y) {
    x_coordinate = x;
    y_coordinate = y;
  }

  int x_coordinate{};
  int y_coordinate{};

  int get_health() { return health_level; }

  bool is_alive() { return health_level > 0; }

  bool hit() {
    if (is_alive()) {
      health_level -= 1;
      return true;
    }
    return false;
  }

  bool teleport(int x_new, int y_new) {
    x_coordinate = x_new;
    y_coordinate = y_new;
    return true;
  }

  bool collision_detection(Alien alien) {
    if (alien.x_coordinate == x_coordinate &&
        alien.y_coordinate == y_coordinate) {
      return true;
    }
    return false;
  }

private:
  int health_level = 3;
};

} // namespace targets
