const moment = require('moment');
const modulen = require('../app/tools');

describe('Test counter eller å', () => {
	it('test_calculation_of_hours_within_the_same_date_is_done_correct', () => {
  	const date1 = moment('2018-01-03T04:00:00.123123+0200').toDate();
    const date2 = moment('2018-01-03T18:00:00.123123+0200').toDate();
  	expect(modulen.count(date1, date2)).toEqual(12.0);
  });
});