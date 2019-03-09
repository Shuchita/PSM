#include "SampleModule.h"
#include "ImportX.h"

//----------------------------------------------------------------
//  module entry
//----------------------------------------------------------------

extern "C" { class SAMPLEMODULE SAMPLEMODULE ; }

bool SAMPLEMODULE::InitModule( MdxShell *shell, int argc, const char **argv )
{
	if ( shell == 0 ) return false ;
	shell->SetProc( 0, new ImportX ) ;
	return true ;
}

void SAMPLEMODULE::ExitModule()
{
	return ;
}
