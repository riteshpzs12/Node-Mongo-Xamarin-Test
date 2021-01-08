db things

1. **User** 
```
    id
    name
    phn no
    address
    email
    /* rest to add */
```

2. **Doctor**
```
   id
   name
   mail
   major category
   special category
   image 
   /* rest to add */
```

3. Appointment Details
```
     doctor id
     availabaility (weekwise string of 7 bit)
     start time
     end time
     visit fee
     clinic id
     slot time
     /* rest to add */
 ```

4. Clinic
```
     clinic id
     clinc name
     location url
     address line 1
     address line 2
     state
     city
     pincode
     multi valued doctor id list...
     /* rest to add */
```

5. Slot 
```
    start time
    end time
    slot day
    doctor id
    booked flag
    reason detail id
    /* rest to add */
```
6. Booked Slots
```
    bucket of all the generated slot ids.. it will be
    doctor id
    list of booked slots(slot ids for that doctor)
    /* rest to add */
```
7. Reason Details
```
    major category
    special category
    comments 
    /* rest to add */
```
8. Login table
```
     type enum
     id
     pass
```
