namespace easypost_api.IAM.Domain.Model.Commands;

/**
 * <summary>
 *     The sign up command
 * </summary>
 * <remarks>
 *     This command object includes the username and password to sign up
 * </remarks>
 */
public record SignUpCommand(
 string Username, 
 string Password,
 string Type,
 string Name, 
 string Description, 
 string Ruc, 
 string Phone, 
 string Email, 
 string Department, 
 string District, 
 string Residential
 );