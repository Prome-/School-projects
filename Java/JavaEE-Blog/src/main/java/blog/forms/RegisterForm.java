package blog.forms;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class RegisterForm 
{
	@NotNull
    @Size(min=4, max=30, message = "Username size should be in the range [4...30]")
    private String username;

    @NotNull
    @Size(min=4, max=50, message = "Password size should be in the range [4...50]")
    private String password;
    
    private String fullName;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

	public String getFullName() {
		return fullName;
	}

	public void setFullName(String fullName) {
		this.fullName = fullName;
	}       
}