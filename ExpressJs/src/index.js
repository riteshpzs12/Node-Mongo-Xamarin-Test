//import dependencies
const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const helmet = require('helmet');
const morgan = require('morgan');
var multer = require('multer');

var mongo = require('mongodb');
var monk = require('monk');
var db = monk('localhost:27017/newtest');

var customerid;
var date = new Date();
var stamp = date.getTime().toString();

var storage = multer.diskStorage({
  destination: function (req, file, cb) {
    cb(null, './uploads/')
  },
  filename: function (req, file, cb) {
    cb(null,stamp+'.png')
  }
})

var upload = multer({ storage: storage }).any(); 

// define the Express app
const app = express();


// enhance your app security with Helmet
app.use(helmet());

// use bodyParser to parse application/json content-type
app.use(bodyParser.json());

// enable all CORS requests
app.use(cors());

// log HTTP requests
app.use(morgan('combined'));

app.use(function(req,res,next){
    req.db = db;
    next();
});



app.get('/rit', function(req, res) {
    var collection = req.db.collection('usercollection');
    collection.find({})
    .then(function(numItems) {
        console.log(numItems); // Use this to debug
      res.send(numItems);
    })
});

app.post('/scanupload', function(req, res) {
  upload(req, res, function (err) {
    if (err instanceof multer.MulterError) {
      console.log("error");
    }
   })
  customerid = req.query.Custid;
  var representativeid = req.query.Repid;
  var rescan = req.query.rescan;
  console.log(customerid+"blah blah blah"+representativeid);  
  var mockcustomerdata = {
    "custid":customerid,
    "userid":representativeid,    
    "imageimg":"https://static.tgstat.ru/public/images/channels/_0/a7/a77c250b287dcf895e3237e1667190b0.jpg",
    "imagename":"soomething"
    ,"imageDOB":"02.02.1996"
    ,"imagesex":"Male"
    ,"imageaddress":"any"
    ,"imageid":"DL1234567"
    ,"qsreponsestring":"0000000000"
  }
  var rescanmockcustomerdata = {
    "custid":customerid,
    "userid":representativeid,    
    "imageimg":"https://static.tgstat.ru/public/images/channels/_0/a7/a77c250b287dcf895e3237e1667190b0.jpg",
    "imagename":"RITESH"
    ,"imageDOB":"02.02.1986"
    ,"imagesex":"Male"
    ,"imageaddress":"anything, LA"
    ,"imageid":"DL1234567"
    ,"qsreponsestring":"0000000000"
  }
  var customer = req.db.get('customer');
  console.log(rescan)
   if(rescan=="true") {
        console.log("updating");
        customer.update({custid:customerid}, rescanmockcustomerdata, function(err, res) {
			if (err) throw err;
             db.close();
 })
      }
    //update
    else {
        console.log("inserting")
        customer.insert(mockcustomerdata, function(err, res) {
			if (err) throw err;
             db.close();
 })
  }
      res.send("success")
});

app.post('/userChoice', function(req, res) {
  customerid = req.query.Custid;  
  var mockresponsedata = {
    "CustID":customerid,
    "first":req.query.first,
    "second":req.query.second,
    "third":req.query.third,
    "fourth":req.query.fourth,
    "fifth":req.query.fifth
  }
  var UserResponse = req.db.get('UserResponse');
        console.log("inserting");
        UserResponse.insert(mockresponsedata, function(err, res) {
			if (err) throw err;
             db.close();
 })
      res.send("success")
});


app.get('/getcustomer', function(req, res) {
  var customer = req.query.custID;  
  console.log('here in db connect to Customer');
    var collection = req.db.get('customer');
    collection.find({custid:customer})
    .then(function(numItems) {
        console.log(numItems); // Use this to debug
      res.send(numItems);
    })
});

app.post('/savecustomer', function(req, res) {
   var mockupdatedata = {
    "custid":req.query.custID,    
    "imagename":req.query.imagename
    ,"imageDOB":req.query.imageDOB
    ,"imagesex":req.query.imagesex
    ,"imageaddress":req.query.imageaddress
    ,"imageid":"DL1234567"
    ,"qsreponsestring":"0000000000"
  }
  var customer = req.db.get('customer');
    customer.update({custid:req.query.custID}, mockupdatedata, function(err, res) {
    if (err) throw err;
    db.close();
 })
 res.send("success");
});


// start the server
app.listen(8081, () => {
  console.log('listening on port 8081');
});