#include <array>
#include <string>
#include <vector>

// Round down all provided student scores.
std::vector<int> round_down_scores(std::vector<double> student_scores) {
  std::vector<int> rounded_scores{};

  for (double score : student_scores) {
    int rounded_score = static_cast<int>(score);
    rounded_scores.push_back(rounded_score);
  }
  return rounded_scores;
}

// Count the number of failing students out of the group provided.
int count_failed_students(std::vector<int> student_scores) {
  int count = 0;
  for (int score : student_scores) {
    if (score <= 40)
      ++count;
  }
  return count;
}

// Determine how many of the provided student scores were 'the best' based on
// the provided threshold.
std::vector<int> above_threshold(std::vector<int> student_scores,
                                 int threshold) {
  std::vector<int> the_best{};
  for (int score : student_scores) {
    if (score >= threshold)
      the_best.emplace_back(score);
  }
  return the_best;
}

// Create a list of grade thresholds based on the provided highest grade.
std::array<int, 4> letter_grades(int highest_score) {
  std::array<int, 4> grades{};
  int interval = (highest_score - 40) / 4;
  for (int i = 0; i < 4; ++i) {
    grades.at(i) = (41 + (i * interval));
  }
  return grades;
}

// Organize the student's rank, name, and grade information in ascending order.
std::vector<std::string>
student_ranking(std::vector<int> student_scores,
                std::vector<std::string> student_names) {
  std::vector<std::string> ranking{student_scores.size()};
  for (int i = 0; i < student_scores.size(); ++i) {
    ranking[i] = std::to_string(i + 1) + ". " + student_names.at(i) + ": " +
                 std::to_string(student_scores.at(i));
  }
  return ranking;
}

// Create a string that contains the name of the first student to make a perfect
// score on the exam.
std::string perfect_score(std::vector<int> student_scores,
                          std::vector<std::string> student_names) {
  for (int i = 0; i < student_scores.size(); ++i) {
    if (student_scores.at(i) == 100)
      return student_names.at(i);
  }
  return "";
}
