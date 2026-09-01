namespace asERP.Application.Mediator;

/// <summary>
/// Opts a request out of the mediator's automatic validation step. Use only when the rules depend on
/// state the validator cannot see and the handler therefore has to validate conditionally itself —
/// not to silence a failing validator.
/// </summary>
public interface ISkipPipelineValidation
{
}
