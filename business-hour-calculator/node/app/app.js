const express = require('express');
const app = express();
const get_business_hour_between_timestamps = require('./tools').get_business_hour_between_timestamps;

app.get('/', (req, res) => {
    res.status(200).send('hello mr');
});

app.get('/business-hour-calculator', (req, res) => {
    res.status(200).send(get_business_hour_between_timestamps('f','s'));
});

app.listen(8080);

console.log('app listening on http://localhost:8080');