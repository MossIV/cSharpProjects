string[,] corporate = 
{
    {"Robert", "Bavin"}, {"Simon", "Bright"},
    {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
    {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};

string[,] external = 
{
    {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
    {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "hayworth.com";

for (int i = 0; i < corporate.GetLength(0); i++) 
{
    displayEmail(corporate,i);
}

for (int i = 0; i < external.GetLength(0); i++) 
{
    displayEmail(external,i,externalDomain);
}

void displayEmail(string[,] emails, int currentEmail,string emailExtension="contoso.com"){
    string first = emails[currentEmail,0];
    string firstTwoLetters = first.Substring(0,2).ToLower();
    string fullEmail = firstTwoLetters+emails[currentEmail,1].ToLower()+"@"+emailExtension;
    Console.WriteLine(fullEmail);
}