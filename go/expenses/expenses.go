package expenses

import "fmt"

// Record represents an expense record.
type Record struct {
	Day      int
	Amount   float64
	Category string
}

// DaysPeriod represents a period of days for expenses.
type DaysPeriod struct {
	From int
	To   int
}

type NoSuchCateory struct {
	category string
}

func (e *NoSuchCateory) Error() string {
	return fmt.Sprintf("unknown category %s", e.category)
}

// Filter returns the records for which the predicate function returns true.
func Filter(in []Record, predicate func(Record) bool) []Record {
	var filtered []Record
	for _, v := range in {
		if predicate(v) {
			filtered = append(filtered, v)
		}
	}
	return filtered
}

// ByDaysPeriod returns predicate function that returns true when
// the day of the record is inside the period of day and false otherwise.
func ByDaysPeriod(p DaysPeriod) func(Record) bool {
	return func(r Record) bool {
		return r.Day >= p.From && r.Day <= p.To
	}
}

// ByCategory returns predicate function that returns true when
// the category of the record is the same as the provided category
// and false otherwise.
func ByCategory(c string) func(Record) bool {
	return func(r Record) bool {
		return r.Category == c
	}
}

// TotalByPeriod returns total amount of expenses for records
// inside the period p.
func TotalByPeriod(in []Record, p DaysPeriod) float64 {
	records := Filter(in, ByDaysPeriod(p))
	var totalExpenses float64 = 0

	for _, rec := range records {
		totalExpenses += rec.Amount
	}
	return totalExpenses
}

// CategoryExpenses returns total amount of expenses for records
// in category c that are also inside the period p.
// An error must be returned only if there are no records in the list that belong
// to the given category, regardless of period of time.
func CategoryExpenses(in []Record, p DaysPeriod, c string) (float64, error) {
	recordsInCategory := Filter(in, ByCategory(c))

	if len(recordsInCategory) == 0 {
		return 0, &NoSuchCateory{category: c}
	}

	return TotalByPeriod(recordsInCategory, p), nil
}
