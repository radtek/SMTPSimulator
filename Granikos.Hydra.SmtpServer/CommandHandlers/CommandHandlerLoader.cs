using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Granikos.Hydra.SmtpServer.CommandHandlers
{
    [Export(typeof (ICommandHandlerLoader))]
    public class CommandHandlerLoader : DefaultModuleLoader<ICommandHandler>, ICommandHandlerLoader
    {
        [ExcludeFromCodeCoverage]
        [ImportingConstructor]
        public CommandHandlerLoader([Import] ComposablePartCatalog catalog)
            : base(catalog, "Command")
        {
        }
    }
}