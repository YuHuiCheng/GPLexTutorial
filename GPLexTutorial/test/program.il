.assembly ConsoleApp1 {}
.class public HelloWorld {
	.method static public void main (String[] args) 
 	{
		.entrypoint 
		.locals init (int x)
		ldc.i4 42
		stloc x
		ret 
 	}
}