using System;

public static class GlobalMembers
{
	public static readonly int broi = 3;
	public static usp[] uspeh = Arrays.InitializeWithDefaultInstances<usp>(broi);

	public static void wywevdane()
	{
		int i;
		int br_u;
		int br_uch;
	  double st_u;
	  double sr_uspeh;
	  double pret_uspeh;
	  br_uch = 0;
	  sr_uspeh = pret_uspeh = 0;
	  for (i = 0;i < broi;i++)
	  {
		  Console.Write("Broj uchenici w grupa ");
		  Console.Write(i + 1);
		  Console.Write(": ");
		  br_u = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
	   uspeh[i].br = br_u; //broj uchenici za grupata
	   br_uch += br_u; //obsh broj uchenici
	   Console.Write("Sreden uspeh za grupa ");
	   Console.Write(i + 1);
	   Console.Write(": ");
	   st_u = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
	   uspeh[i].stojn = st_u; // stojnost za uspeh na grupata;
	   sr_uspeh += st_u;
	  }
	  Console.Write("Sredno aritmetichno - sredna stojnost za uspeha: ");
	  Console.Write(sr_uspeh / broi);
	  Console.Write("\n");
	  for (i = 0;i < broi;i++)
	  {
		   pret_uspeh += uspeh[i].br * uspeh[i].stojn;
	  }
		Console.Write("Sredna preteglena stojnost za uspeha: ");
		Console.Write(pret_uspeh / br_uch);
		Console.Write("\n");
	} // sredna stojnost

	static int Main()
	{
		char ose;
	 Console.Write("Imate N - estestweno chislo ot interwala [5..10] i N na broj\n");
	 Console.Write("dwojki chisla predstwlqwashi: broi uchenici w grupi [2..30], kakto i\n");
	 Console.Write("sredniq uspeh za grupata [2.01..6.00].\n");
	 Console.Write("Da se systawi programa, chrez koqto se wywevdat N dwojki chisla i se\n");
	 Console.Write("izwevda sredna stojnost i sredna preteglena stojnost za tezt danni.\n");
	 Console.Write("Primer: 3, 2.5; 4, 4.25; 5 5.25 Izhod: 4 4.22917\n");
	 do
	 {
	   wywevdane();
	   Console.Write("Velaete li nowo mnovestwo ot chisla <y/n>: ");
	   ose = ConsoleInput.ReadToWhiteSpace(true)[0];
	 } while (ose == 'y');
	 
	 return 0;
	} //kraj na programa sredna preteglena stojnost

}