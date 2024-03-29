#include <string>
#include <vector>

namespace election {

struct ElectionResult {
  // Name of the candidate
  std::string name{};
  // Number of votes the candidate has
  int votes{};
};

// vote_count takes a reference to an `ElectionResult` as an argument and will
// return the number of votes in the `ElectionResult.
int vote_count(ElectionResult &election_result) {
  return election_result.votes;
}

// increment_vote_count takes a reference to an `ElectionResult` as an argument
// and a number of votes (int), and will increment the `ElectionResult` by that
// number of votes.
void increment_vote_count(ElectionResult &election_result, int votes) {
  election_result.votes += votes;
}

// determine_result receives the reference to a final_count and returns a
// reference to the `ElectionResult` of the new president. It also changes the
// name of the winner by prefixing it with "President". The final count is given
// in the form of a `reference` to `std::vector<ElectionResult>`, a vector with
// `ElectionResults` of all the participating candidates.
ElectionResult &determine_result(std::vector<ElectionResult> &final_count) {
  ElectionResult &winner = final_count.at(0);
  for (int i = 0; i < final_count.size(); ++i) {
    if (final_count.at(i).votes > winner.votes) {
      winner = final_count.at(i);
    }
  }
  winner.name = "President " + winner.name;
  return winner;
}

} // namespace election
