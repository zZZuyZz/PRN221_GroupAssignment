CREATE DATABASE RealEstateManagement
GO

USE RealEstateManagement
GO

CREATE TABLE Roles (
    Id uniqueidentifier primary key,
	RoleName nvarchar(50)
);
GO

CREATE TABLE Users (
    Id uniqueidentifier PRIMARY KEY,
    UserName nvarchar(50),
	Email nvarchar(50) ,
    [Password] nvarchar(255),
	Phone nvarchar(50),
    RoleId uniqueidentifier,
	IsActive tinyint,
	CreatedAt datetime,
	CreatedBy nvarchar(50),
    UpdatedAt datetime,
	UpdatedBy nvarchar(50),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
GO

CREATE TABLE Projects(
	Id uniqueidentifier PRIMARY KEY,
	InvestorId uniqueidentifier,
	ProjectStatus nvarchar(50),
	ProjectLocation nvarchar(50),
	ProjectGeoLocationUrl nvarchar(50),
	StartDate datetime,
	EndDate datetime,
	ProjectTitle nvarchar(255),
	ProjectContent nvarchar(255),
	CreatedAt datetime,
	CreatedBy nvarchar(50),
    UpdatedAt datetime,
	UpdatedBy nvarchar(50),
	FOREIGN KEY (InvestorId) REFERENCES Users(Id)
);
GO

CREATE TABLE Products  (
    Id uniqueidentifier PRIMARY KEY,
    InvestorId uniqueidentifier,
	FinalCustomerId uniqueidentifier,
	ProjectId uniqueidentifier,
    Address nvarchar(255),
    Sescription TEXT,
    Price DECIMAL(15, 2),
    Status nvarchar(50),
	CreatedAt datetime,
	CreatedBy nvarchar(50),
    UpdatedAt datetime,
	UpdatedBy nvarchar(50),
    FOREIGN KEY (InvestorId) REFERENCES Users(Id),
	FOREIGN KEY (FinalCustomerId) REFERENCES Users(Id),
	FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
);
GO

CREATE TABLE Bookings(
    Id uniqueidentifier PRIMARY KEY,
    ProductId uniqueidentifier,
    CustomerId uniqueidentifier,
    AgencyId uniqueidentifier,
	BookingUserName nvarchar(255),
	PhoneNumber nvarchar(50),
	Content nvarchar(255),
    BookingDate datetime,
    [Status] nvarchar(50),
	CreatedAt datetime,
	CreatedBy nvarchar(50),
    UpdatedAt datetime,
	UpdatedBy nvarchar(50),
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (CustomerId) REFERENCES Users(Id),
    FOREIGN KEY (AgencyId) REFERENCES Users(Id)
);
GO

CREATE TABLE Contracts (
    Id uniqueidentifier PRIMARY KEY,
    ProductId uniqueidentifier,
    CustomerId uniqueidentifier,
    AgencyId uniqueidentifier,
    DepositAmount DECIMAL(15, 2),
    ContractDate DATE,
    [Status] nvarchar(50),
	CreatedAt datetime,
	CreatedBy nvarchar(50),
    UpdatedAt datetime,
	UpdatedBy nvarchar(50),
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (CustomerId) REFERENCES Users(Id),
    FOREIGN KEY (AgencyId) REFERENCES Users(Id)
);
GO

-- INSERT ROLES
insert into Roles (id, RoleName) values ('4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 'Admin');
insert into Roles (id, RoleName) values ('22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 'Agency');
insert into Roles (id, RoleName) values ('0990d0fd-3f8c-4a3b-99db-912473a08df0', 'Investor');
insert into Roles (id, RoleName) values ('43090161-855a-4d9f-ac61-b4a2432a199e', 'Customer');
GO

--INSERT USERS
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('16999f06-d974-44f9-91b9-186a084c6b6c', 'admin', 'admin@gmail.com', '123456', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('5f854d8c-ee63-46bc-ad09-31dd6aac3b0e', 'agency', 'agency@gmail.com', '123456', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('9afe7645-cf4c-4777-9125-a34e73291d14', 'investor', 'investor@gmail.com', '123456', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('314f3de7-ed73-4b08-aad6-c2ccbecd32c2', 'customer', 'customer@gmail.com', '123456', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('37119762-b213-4bb0-be7f-39e3d3b463b4', 'kdraycott0', 'sshimmin0@pinterest.com', 'pL9>7''$o6+nJ7', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('0c655fb0-8090-4f1d-a947-f436c2ea9b0e', 'mmancktelow1', 'avasilyevski1@yale.edu', 'hJ4_sT4nd*j}', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('77718fc2-83ff-4a3e-aafd-668312d539b5', 'blorenzetto2', 'acestard2@cloudflare.com', 'fT8?,BN>=z!4>%M9', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('8cb3ae40-68c4-46de-ab99-867f03b8262c', 'lproctor3', 'kstickney3@army.mil', 'fH5@Q7Ksb', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('dc01dab9-d644-48d6-a3ad-f1d10e783609', 'ledser4', 'dmaclachlan4@xing.com', 'oV2<h"2C0', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('eecca6e8-4a9f-42f1-a02d-c86d7a37d8fe', 'tdrever5', 'njanew5@google.ca', 'lX5~oi`,', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('ff1036a4-43e1-4b90-8994-708ef394ca29', 'rmarran6', 'carmell6@tinyurl.com', 'lN8=~6T$VC%*\iWZ', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('ba59c85b-b640-47a9-93e9-75a9a98e8a00', 'cgrissett7', 'eparcells7@amazon.co.uk', 'fC2+<zR\2', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('abf35aef-62ed-451f-8e09-64964b63143b', 'pmargett8', 'ebraams8@blogs.com', 'uC6<_da3', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('f548cc45-f91f-4927-a273-8af144beb7d1', 'cphilippet9', 'fnoble9@aboutads.info', 'dF5}iHE!''{"d', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('abd10afe-644b-43b3-968b-a34341a78f73', 'sroffa', 'mcusta@netlog.com', 'nN2,47yvnu.au%', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('c93b9bc2-a140-4cd9-8a21-573284634264', 'lortigerb', 'laishb@craigslist.org', 'cW8$|y#B)X''}1', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('480eead1-edf4-4489-a348-8ab7729fb3fd', 'mhenrietc', 'nspearmanc@sun.com', 'yJ7?w4T3vK\)M', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('96e4af8a-5b71-4f65-b8e0-f13334d62893', 'dclutramd', 'pnouryd@japanpost.jp', 'gD3"87$clpjNBlv', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('58f305f0-c950-4717-9882-260268c8be5b', 'cwegnere', 'fmarciskewskie@godaddy.com', 'iV5\?)79j"`md>', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('c39f9622-e52b-4a7d-978c-b4f46be2632b', 'akryszkaf', 'kinkpinf@wunderground.com', 'dU1(wF!h|ktd/', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('44888726-e433-423a-9151-9318cc4bdee0', 'ualvyg', 'tgladerg@trellian.com', 'cE6#_C"6a*', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('72c9ea98-0a27-4170-ab4c-c2b011b2b0e5', 'mharrodh', 'blilloeh@sfgate.com', 'sB8~2)LN@+/g', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('8e7caaf5-d4b5-45a5-9e74-344bae66b519', 'jjanuszkiewiczi', 'cjosefseni@bizjournals.com', 'xL5=<!Mc)BRYY', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('e4f9991f-fd34-459c-af8b-2b51d36ec12e', 'akleiselj', 'mmcswanj@blogger.com', 'lX2*2nxG$U8l@u"', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('0bfe523b-7f72-4ec7-9d9e-b321947fd951', 'rmcneishk', 'pwynrahamek@reddit.com', 'yJ3\0Sn~ttU4Ca', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('b36a1b8f-4eec-44f8-8fb5-7eb855b78abf', 'dsilbertl', 'dedgellerl@google.ca', 'tE4`RN6Sp\', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('8393a3b4-80f3-444e-ad86-403e4e338636', 'scrippesm', 'jtinklinm@histats.com', 'bH5&<=?mBX\p', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('22e3c970-953f-43b3-8bf0-189c46aad84e', 'cfronekn', 'pfeeleyn@google.com.hk', 'wB0}!=`D@vYQ|', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('e286e5a8-2a35-4b53-adfb-23a358a4dbd3', 'gwabersicho', 'mleinthallo@biblegateway.com', 'sZ4.|w0Y7n%d', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('12ceb29b-96d7-432e-a149-496e65f22e47', 'acissellp', 'ojancarp@joomla.org', 'xY9,Q)ct%p(GzN', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('4792acde-9460-475f-bf03-977d98e092da', 'bmurbyq', 'vcissenq@bing.com', 'eU9*K$7(O/53iYu', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('21aba368-d337-48c1-87d2-eaadc2b7bad5', 'apescodr', 'mimlockr@tinypic.com', 'jF2%=R89u', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('77ae97f3-fe8c-413c-b647-90898c11bbb5', 'sgiovanis', 'ddupres@psu.edu', 'zR1\$JIRh', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('eeae4daf-aadf-4fb0-bf11-6031f9e3694b', 'ctolumellot', 'kmaultt@princeton.edu', 'zR0|$zzmLaXruNWl', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('a1f53ffb-3f18-40b2-b3e7-64d6c2aad31a', 'dmalickiu', 'amabbsu@wikimedia.org', 'wA1`Dv}4qcnE.FyG', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('19c51b48-f6d2-409b-bc83-29d36b6d8e4f', 'urolfiniv', 'kdayerv@earthlink.net', 'sG7+"sGk8Mjwl1''D', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('df88f219-fc13-4104-91c7-1b873f8b8ba3', 'dbrashierw', 'cwildingw@godaddy.com', 'kJ1_@X)3F', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('d6630938-5832-4cec-bc54-5af1b4e4cb27', 'tkindlesidex', 'ckerfordx@bbc.co.uk', 'uU2{?AtN\yx%cPO', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('c8dda38c-dd7b-4768-a915-6979b29416b0', 'trenahany', 'slippardy@ucoz.com', 'qH9*B{S84AZ$ta/"', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('7760de59-05e8-4ef8-acde-2b567b26d55a', 'dpiatkowz', 'nchadwinz@un.org', 'uP1''3{t3e,t_&fX`', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('b912fef3-ef13-49ad-b934-a2ca837d0482', 'ctytterton10', 'sruslin10@hp.com', 'yM3"y0+isvvZo', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('7b649a19-2e9a-45cd-a2f4-b68c0b69bef2', 'kyacob11', 'mmacourek11@twitpic.com', 'oL3/,5nmd7riy', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('c6f8fe9e-5781-421f-b95f-506be64353d6', 'cbartolic12', 'dcogdell12@ebay.co.uk', 'yQ0$P!d>oU}', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('f854c79a-1c32-4692-bb37-32e5a445a48d', 'hgrishelyov13', 'gleijs13@washington.edu', 'zS6`{zjuEF', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('99258a26-5d62-4497-8209-a58030dde12e', 'tmacilory14', 'acoots14@paginegialle.it', 'rN5@g|ta#AI9)5', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('4d526079-588d-449a-9782-f2d917a85531', 'eandrysiak15', 'uanan15@printfriendly.com', 'fD2@f,3\3oPCoj', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('af780931-6249-4128-a16e-cc323b744808', 'bbartalin16', 'cfranckton16@redcross.org', 'uA3)Qi#+dw_', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('5b9aa6a3-2bd7-4432-8a60-19ee1c9a6c33', 'mmasurel17', 'ggookey17@imageshack.us', 'iE8<K`pB9brw*', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('05b49650-b82c-43c2-86fa-78e4b8662b3e', 'bbontine18', 'jnind18@t-online.de', 'fW1|QX."dV.', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('5fd8445f-4e6a-4d77-8463-f4b785a75206', 'rpamplin19', 'gmccahey19@amazon.co.jp', 'eW8@m3evDj0D9"~h', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('0fbcb483-dbd0-4d7e-bc4f-a7a3fafa5407', 'kandrichak1a', 'anice1a@amazon.com', 'fS1>?Rfk2', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('945d925f-b338-4f8d-998c-407ea1db9caa', 'lclementucci1b', 'vodogherty1b@boston.com', 'lP4<.''C+tH=', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('88286575-1a6a-4d56-8d2e-d5b551ec36a1', 'krex1c', 'mdangerfield1c@deliciousdays.com', 'aK1/m0_dJT', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('d078bddd-2121-42c6-a0d6-7738a795380e', 'ccantillion1d', 'iantrobus1d@washingtonpost.com', 'yU1,rlD(1saQW', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('ee9e4698-0ca1-4afd-9dd7-22734454fe89', 'imalinson1e', 'cgalilee1e@ebay.com', 'eT0#w7)vpVD', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('1da0d62d-5a62-4b29-92a2-ac9afb30bd7f', 'jchucks1f', 'jlittlechild1f@virginia.edu', 'sL9#w5._', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('19269bce-cb26-4bb4-9002-5a72829550f9', 'rwalas1g', 'kwroe1g@blogtalkradio.com', 'gL5(jEs\i', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('23bab0d1-28ed-4eb9-a959-a0b2161f3349', 'amassy1h', 'aweight1h@prnewswire.com', 'pZ8)#"y\zo0gR', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('6ec77033-75b7-418b-a7e0-5d3a68653af2', 'cbiagini1i', 'tdeards1i@businessweek.com', 'bS1.GZ1l)p3*', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('ec68efe9-e5e0-4bd5-9e66-c45fb67ecae0', 'dsargeaunt1j', 'cfishley1j@mayoclinic.com', 'rW1~lM1UL~5M', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('0cce1010-62bf-4c7a-b8f7-6097f1470543', 'nbanisch1k', 'ajacquest1k@yellowbook.com', 'cF0_AM{n"P`k,_Az', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('fb9488af-b76f-4fb7-a727-36fc1015a2e0', 'cskipton1l', 'hwolfindale1l@altervista.org', 'gS8_WrJ"G1E~`', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('d15c74c5-8ee3-4971-9237-554f490a03c5', 'ryarr1m', 'jmelhuish1m@oaic.gov.au', 'xT7{*5OHIpa', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('883097e2-29a3-41ce-b791-9c1b82705efd', 'jrothwell1n', 'oswainsbury1n@adobe.com', 'nO5''g6}O+r`$)n>O', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('4d7fab8f-b1e4-4c0b-ab43-bf309c788cbd', 'sstorrar1o', 'mpedron1o@prnewswire.com', 'bM7_.IgEyp=', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('4eff305d-779e-47dc-abf4-96ec14570ca8', 'ablay1p', 'tcoole1p@comcast.net', 'aZ8,rprgi', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('44f0e15a-7a31-4c01-9b9f-c6c8ec52bc6c', 'mlusher1q', 'btirrey1q@infoseek.co.jp', 'gI2@L4"nr', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('8a6ae9f3-f941-4de8-8ef6-eba660dd654f', 'woferris1r', 'gmallall1r@bizjournals.com', 'uH4@n(SmQqU`,w', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('170462d4-28c7-4fbb-88b0-9c5f6833f6e3', 'edunford1s', 'kfardoe1s@hibu.com', 'vO6<d4jt&', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('9fd4d956-1f82-4aa8-85a9-7f15de4806e6', 'dpound1t', 'cwillison1t@theatlantic.com', 'dZ2"V{`T.{f*}', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('2353d5cf-771e-45ab-abb0-537bb65d3caa', 'rstorr1u', 'vteffrey1u@i2i.jp', 'sH8\h4.r~|<U(X{_', '43090161-855a-4d9f-ac61-b4a2432a199e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('ef391839-a480-4c70-bf7f-be31b8ed7473', 'rwimlett1v', 'lsemper1v@tripod.com', 'cK3#51R0JJqWfAFo', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('c64133f9-eae2-430d-a578-e3483fb7b678', 'edeangelo1w', 'telderfield1w@yahoo.co.jp', 'lY1+H7A=!`"', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('5ec0ca75-5c40-4c4e-8b14-717a2ca6587d', 'dmckerron1x', 'edouce1x@cargocollective.com', 'qN7#AIORM4,sk9', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('e0eef357-ac94-4fd6-894d-c34fd7d1f391', 'mmanilo1y', 'bstill1y@delicious.com', 'jV6,XnR!qm', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('d7689f65-f5c4-45de-9530-1e35f03929d9', 'agirodon1z', 'mlasselle1z@economist.com', 'sT3~Pzym', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('055407df-3f83-4aef-beb9-6ff14a82e9da', 'cpettus20', 'ghaily20@usa.gov', 'yC0}|MppN', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('90bfd5e8-b407-4b9a-b941-c5991c012c48', 'gmandrey21', 'tdarkin21@economist.com', 'dL1!A~~e`$y@$K', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('7cc75718-11e0-413f-bb72-52201792ba6d', 'egarnham22', 'rmccole22@hc360.com', 'oG1_tIE>v>5/JDM', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('c6547dde-dace-44c8-bb53-90decc45f4bb', 'lcorkell23', 'bsatterthwaite23@diigo.com', 'dT4<LMS>|3JrUA0', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('322881b0-d44a-4f4e-a100-d4c94541e247', 'vdeane24', 'hwoolnough24@rambler.ru', 'vV4)=PzsuP7zC$', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('13b83b30-200d-4db1-8c9b-173a64b38ba6', 'plohmeyer25', 'gdickens25@behance.net', 'yE2~4EY)sXCY', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('66888c98-d9bf-4a94-a2dc-fe966bb45c60', 'sronchka26', 'etorrent26@constantcontact.com', 'dH2}+z9}', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('a01bc7d7-5731-4bc7-8578-b48ffefaf141', 'jrosenblath27', 'mcussons27@goo.gl', 'hR4''G<IfIFz8i', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('f56e3d1a-7de3-48e2-a7c7-c63d54985bcd', 'nold28', 'tbrindle28@gizmodo.com', 'qP8$I(X4_|A1', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('03c2c31f-50ef-4316-a518-f5ffb75f886f', 'amenure29', 'mdurrett29@4shared.com', 'jA4\ef}mHdi_S1', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('4f804f91-43d2-4888-8470-ec893694f772', 'ccastellini2a', 'smaty2a@toplist.cz', 'gT9)F_jhz@`SpCD*', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('84bd767f-77b7-4b15-a17e-439feae21d7c', 'cribbens2b', 'dkeat2b@yolasite.com', 'lY7(,O#y4<X}', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('d936748c-e63f-4562-b3ad-bfc91cb67f04', 'bmandre2c', 'gfant2c@elpais.com', 'jW5&63xJzaH''mo', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('807f62f5-be7c-4bfc-acb6-f0b256ce426f', 'ecruttenden2d', 'rhuddart2d@uiuc.edu', 'eZ7$,8''tFK1c8', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('b96230e5-cbc4-4cf6-843f-3d63dc25e114', 'lhazeman2e', 'epadbury2e@imageshack.us', 'pJ7!9j4S*@)`h', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('473f6b42-8825-4c60-8a3c-fb0b4e00f975', 'hdowyer2f', 'dzeplin2f@seesaa.net', 'yG6=O9|_X|W&''z"', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('166970b6-e485-4208-afdf-6a3b0e989332', 'eannice2g', 'jahrendsen2g@ezinearticles.com', 'tD6/sFWU', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('cb78c95d-7ddf-476c-9b4f-65221bf9777b', 'mbalaizot2h', 'nstile2h@kickstarter.com', 'aM4<lvW.', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('2c155b13-d219-47d2-957f-5e1ddb924c67', 'nlucia2i', 'lalchin2i@tripod.com', 'xZ4+$>c"m', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('d6f4e6b6-660f-473c-9233-0927438d0a7d', 'mphysic2j', 'jospellissey2j@purevolume.com', 'kN8)x~"If', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('ed125566-1612-4785-a6b6-33119aeb9d25', 'mspeirs2k', 'qcritchley2k@yelp.com', 'bE1.h4tc\', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('7c2a37ee-5bab-4aad-8288-a266be061148', 'cteare2l', 'icasellas2l@rediff.com', 'pU2(l2Wn.1$U', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('f53f2b9d-570c-4adb-a708-cafe1177b1fe', 'mhexam2m', 'leyeington2m@wikia.com', 'bT6..ee2i$\bo', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('20181e31-7e23-43db-be29-f3a6e78fa234', 'rdaverin2n', 'missacof2n@yale.edu', 'lF2?~B8w)nmgK', '22fa1ba0-3aac-4f0e-96ed-bfdfcd780a5e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('f0ff3003-b158-4b75-a528-85b5e86d7d15', 'fdolby2o', 'tmacbey2o@unblog.fr', 'iB4{e5,rCb`''H', '43090161-855a-4d9f-ac61-b4a2432a199e', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('7f1c22e3-0c36-419e-a9d8-7c4ee0c9f6d8', 'dstranieri2p', 'zscuse2p@weibo.com', 'nO7`YeiI<!UHY', '0990d0fd-3f8c-4a3b-99db-912473a08df0', 0);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('9382b42c-c7ea-4a10-ad32-cfe52fadcbe6', 'slawlance2q', 'cgert2q@washingtonpost.com', 'jB7(B?c!', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 1);
insert into Users (id, UserName, Email, Password, RoleId, IsActive) values ('4e3288d3-9e45-45f8-bf70-d4e0c306aef6', 'btumilty2r', 'bbarden2r@dion.ne.jp', 'qP3)kG0("D13m}lX', '4c5fa928-9cb1-46ad-abe2-7170c35d6c72', 0);

-- 