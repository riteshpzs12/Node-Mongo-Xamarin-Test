db things

1. **user** 
```
    id
    name
    phn no
    address
    email
    /* rest to add */
```

2. **doctor**
```
   id
   name
   mail
   major category
   special category
   image 
   /* rest to add */
```

3. appointment details
     doctor id
     availabaility (weekwise string of 7 bit)
     start time
     end time
     visit fee
     clinic id
     slot time
     * rest to add

4. Clinic
     clinic id
     clinc name
     location url
     address line 1
     address line 2
     state
     city
     pincode
     multi valued doctor id list...
     * rest to add

5. slot 
    start time
    end time
    slot day
    doctor id
    booked flag
    reason detail id
    * rest to add

6. booked slots()
    bucket of all the generated slot ids.. it will be
    doctor id
    list of booked slots(slot ids for that doctor)
    * rest to add

7. reason details
    major category
    special category
    comments 
    * rest to addd

8.  login table
     type enum
     id
     pass
