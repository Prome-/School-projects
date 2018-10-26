// load all the things we need
var LocalStrategy   = require('passport-local').Strategy;
var bcrypt = require('bcrypt-nodejs');

// expose this function to our app using module.exports
module.exports = function(passport, connection) {

    // =========================================================================
    // passport session setup ==================================================
    // =========================================================================
    // required for persistent login sessions
    // passport needs ability to serialize and unserialize users out of session

    // serialisoinnin ymmärtämiseen
    // http://stackoverflow.com/questions/27637609/understanding-passport-serialize-deserialize

    // used to serialize the user for the session
    passport.serializeUser(function(user, done) {
        console.log("Serializing. User id: " + user.id);        
        done(null, user.id);
    });

    // used to deserialize the user
    passport.deserializeUser(function(id, done) {
        connection.query("SELECT * FROM User WHERE id = ? ",[id], function(err, rows){
            console.log("Deserializing. User email: " + rows[0].email);
            done(err, rows[0]);
        });
    });

    // =========================================================================
    // LOCAL SIGNUP ============================================================
    // =========================================================================


    passport.use('local-signup', new LocalStrategy({
            // by default, local strategy uses username and password, we will override username with email
            usernameField : 'email',
            passwordField : 'password',
            passReqToCallback : true // allows us to pass back the entire request to the callback
        },
        function(req, email, password, done) {
            console.log("Processing signup...");
            // find a user whose email is the same as the forms email
            // we are checking to see if the user trying to login already exists
            connection.query("SELECT * FROM User WHERE email = ?",[email], function(err, rows) {
                if (err){
                    console.log("Error occurred! " + err);
                    return done(err);
                }                    
                if (rows.length) {
                    console.log("Email already taken.");

                    return done(null, false, req.flash('signupMessage', 'That username is already taken.'));
                } else {
                    // if there is no user with that email
                    // create the user
                    var salt = bcrypt.genSaltSync(10);
                    var firstname = req.body.firstname;
                    var lastname = req.body.lastname;
                    var newUserMysql = {
                        firstname: firstname,
                        lastname: lastname,
                        email: email,                        
                        password: bcrypt.hashSync(password, salt)  // use the generateHash function in our user model
                    };

                    var insertQuery = "INSERT INTO User ( firstname, lastname, email, password ) values (?,?,?,?)";

                    connection.query(insertQuery,[newUserMysql.firstname,newUserMysql.lastname, newUserMysql.email, newUserMysql.password],function(err, rows) {
                        newUserMysql.id = rows.insertId;
                        console.log("Signup ok.");                      
                        return done(null, newUserMysql);
                    });
                }
            });
        })
    );

    // =========================================================================
    // LOCAL LOGIN =============================================================
    // =========================================================================


    passport.use('local-login',new LocalStrategy({
            // by default, local strategy uses username and password, we will override username with email
            usernameField : 'email',
            passwordField : 'password',
            passReqToCallback : true // allows us to pass back the entire request to the callback
        },
        function(req, email, password, done) { // callback with email and password from our form
            console.log("Processing login...");
            connection.query("SELECT * FROM User WHERE email = ?",[email], function(err, rows){
                if (err){
                    console.log("Error occurred! " + err);
                    return done(err);
                }
                if (!rows.length) 
                {
                    console.log("Invalid email!");
                    return done(null, false, req.flash('loginMessage', 'No user with entered email found.')); // req.flash is the way to set flashdata using connect-flash
                }

                // if the user is found but the password is wrong
                if (!bcrypt.compareSync(password, rows[0].password)){
                    console.log("Invalid password!");
                     return done(null, false, req.flash('loginMessage', 'Oops! Wrong password.')); // create the loginMessage and save it to session as flashdata
                }
                   

                // all is well, return successful user
                console.log("Login ok.");    
                return done(null, rows[0]);
            });
        })
    );
};