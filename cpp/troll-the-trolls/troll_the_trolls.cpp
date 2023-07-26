namespace hellmath {

// Task 1 - Define an `AccountStatus` enumeration to represent the four
// account types: `troll`, `guest`, `user`, and `mod`.
enum class AccountStatus { troll, guest, user, mod };

// Task 1 - Define an `Action` enumeration to represent the three
// permission types: `read`, `write`, and `remove`.
enum class Action { read, write, remove };

//  Task 2 - Implement the `display_post` function, that gets two arguments
// of `AccountStatus` and returns a `bool`. The first argument is the status of
// the poster, the second one is the status of the viewer.
bool display_post(AccountStatus poster_status, AccountStatus viewer_status) {
  if (poster_status == AccountStatus::troll) {
    return viewer_status == AccountStatus::troll;
  }
  return true;
}

// Task 3 - Implement the `permission_check` function, that takes an
// `Action` as a first argument and an `AccountStatus` to check against. It
// should return a `bool`.
bool permission_check(Action action, AccountStatus status) {

  switch (status) {
  case AccountStatus::guest:
    return action == Action::read;
  case AccountStatus::user:
    return action == Action::read || action == Action::write;
  case AccountStatus::troll:
    return action == Action::read || action == Action::write;
  case AccountStatus::mod:
    return action == Action::read || action == Action::write ||
           action == Action::remove;
  default:
    return false;
  }
}

// Task 4 - Implement the `valid_player_combination` function that
// checks if two players can join the same game. The function has two parameters
// of type `AccountStatus` and returns a `bool`.
bool valid_player_combination(AccountStatus status1, AccountStatus status2) {
  if (status1 == AccountStatus::guest || status2 == AccountStatus::guest) {
    return false;
  }
  if (status1 == AccountStatus::troll && status2 != AccountStatus::troll) {
    return false;
  }
  if (status1 != AccountStatus::troll && status2 == AccountStatus::troll) {
    return false;
  }
  return true;
}

// Task 5 - Implement the `has_priority` function that takes two
// `AccountStatus` arguments and returns `true`, if and only if the first
// account has a strictly higher priority than the second.
bool has_priority(AccountStatus status1, AccountStatus status2) {
  return status1 > status2;
}

} // namespace hellmath
