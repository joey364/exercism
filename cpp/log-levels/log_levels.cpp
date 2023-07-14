#include <string>
using namespace std;

namespace log_line {

string message(string log_line) {
  int space_idx = log_line.find_first_of(" ");
  return log_line.substr(space_idx + 1);
}

string log_level(string log_line) {
  int bracket_start = log_line.find_first_of("[");
  int bracket_end = log_line.find_first_of("]");
  return log_line.substr(bracket_start + 1, bracket_end - bracket_start - 1);
}

string reformat(string log_line) {
  string msg = message(log_line);
  string level = log_level(log_line);

  return msg + " " + "(" + level + ")";
}

} // namespace log_line
