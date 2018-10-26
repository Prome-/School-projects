package blog.controllers;

import blog.forms.LoginForm;
import blog.services.NotificationService;
import blog.services.UserServiceJpaImpl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCrypt;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;
import javax.validation.Valid;

@Controller
public class LoginController 
{
	private final static int workload = 10;

    @Autowired
    private UserServiceJpaImpl userService;

    @Autowired
    private NotificationService notifyService;
    
    @Autowired
    private HttpServletRequest request;

    @RequestMapping(value = "/users/login", method = RequestMethod.POST)
    public String loginPage(@Valid LoginForm loginForm, BindingResult bindingResult) {
        if (bindingResult.hasErrors()) {
             notifyService.addErrorMessage("Please fill the form correctly!");
             return "users/login";
        }
        
        if (!userService.authenticate(        	
        		loginForm.getPassword(), loginForm.getPassword())) {
             notifyService.addErrorMessage("Invalid login!");
             return "users/login";
        }
        
        notifyService.addInfoMessage("Login successful");
        // Kirjautunut käyttäjä sessioniin, default timeout Tomcatissa 30min
        HttpSession session = request.getSession();  
        session.setAttribute("user", loginForm.getUsername());  
        return "redirect:/";
    }
    
    @RequestMapping(value = "/users/login", method = RequestMethod.GET)
    public String login(LoginForm loginForm) {
        return "users/login";
    }
    
}