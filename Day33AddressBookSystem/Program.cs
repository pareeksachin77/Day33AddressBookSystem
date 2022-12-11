// See https://aka.ms/new-console-template for more information

using Day33AddressBookSystem;

AddressBookSystem contact = new AddressBookSystem();
Console.WriteLine("SQL Operations\n0.Exit\n1.Show Data\n2.Update Data\n3.Delete Record\n4.Create Record\nEnter Your choice:");
int choice = Convert.ToInt32(Console.ReadLine());
while (choice != 0)
{
    switch (choice)
    {
        case 1:
            contact.getData();
            break;
        case 2:
            contact.UpdateRecord();
            break;
        case 3:
            contact.DeleteRecord();
            break;
        case 4:
            contact.createRecord();
            break;
        default:
            Console.WriteLine("Enter valid choice.");
            break;
    }
    Console.WriteLine("SQL Operations\n0.Exit\n1.Show Data\n2.Update Data\n3.Delete Record\n4.Create Record\nEnter Your choice:");
    choice = Convert.ToInt32(Console.ReadLine());
}
