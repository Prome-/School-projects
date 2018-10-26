package blog.controllers;

import blog.forms.RegisterForm;
import blog.models.User;
import blog.repositories.UserRepository;
import blog.services.NotificationService;
import blog.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCrypt;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import javax.validation.Valid;

@Controller
public class RegisterController 
{
	private final static int workload = 10;
	
    @Autowired
    private UserService userService;
    
    @Autowired
    private UserRepository userRepository;

    @Autowired
    private NotificationService notifyService;

    @RequestMapping("/users/register")
    public String login(RegisterForm registerForm) {
        return "users/register";
    }

    @RequestMapping(value = "/users/register", method = RequestMethod.POST)
    public String registerPage(@Valid RegisterForm registerForm, BindingResult bindingResult) {
    	System.out.println("Recieved register post");
        if (bindingResult.hasErrors()) {
             notifyService.addErrorMessage("Please fill the form correctly!");
             return "users/register";
        }
           
        try
        {
            User newUser = new User();        
            newUser.setUsername(registerForm.getUsername());            
            newUser.setPasswordHash(hashPassword(registerForm.getPassword()));
            newUser.setFullName(registerForm.getFullName());
            newUser.setRole("user");
                        
            userRepository.save(newUser);
            notifyService.addInfoMessage("Register successful");
        }
        catch(Exception e)
        {
        	e.printStackTrace();
        }        
        
        return "redirect:/";
    }
    
    public static String hashPassword(String password_plaintext) {
		String salt = BCrypt.gensalt(workload);
		String hashed_password = BCrypt.hashpw(password_plaintext, salt);

		return(hashed_password);
	}
}