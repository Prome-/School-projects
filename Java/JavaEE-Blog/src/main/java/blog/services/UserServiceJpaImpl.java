package blog.services;

import blog.models.User;
import blog.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.security.crypto.bcrypt.BCrypt;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Objects;

@Service
@Primary
public class UserServiceJpaImpl implements UserService 
{
	@Autowired
	private UserRepository userRepo;
	
	@Override
	public List<User> findAll() {
	return this.userRepo.findAll();
	}
	
	@Override
	public User findById(Long id) {
	return this.userRepo.findOne(id);
	}
	
	@Override
	public User findByUsername(String name) {
	return this.userRepo.findByUsername(name);
	}
	
	@Override
	public User create(User user) {
	return this.userRepo.save(user);
	}
	
	@Override
	public User edit(User user) {
	return this.userRepo.save(user);
	}
	
	@Override
	public void deleteById(Long id) {
	this.userRepo.delete(id);
	}
	
	@Override
	public boolean authenticate(String username, String password)
	{
		boolean result = false;
		try		{
			User user = userRepo.findByUsername(username);			
			//System.out.println("Found username: " + user.getUsername() + ", found password: " + user.getPasswordHash());
			//System.out.println("Given username: " + username + ", given password: " + password);
			
			if(BCrypt.checkpw(password, user.getPasswordHash())){
				System.out.println("Password match, returning TRUE");
				result = true;
			}			
			else{
				System.out.println("Password mismatch, returning FALSE");
				result = false;
			}
		}
		catch(Exception e)		{
			System.out.println("No given user found");
		}
		
		return result;
	}
}