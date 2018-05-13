using System;
using System.Collections.Generic;

namespace CMSCore.Content.IntegrationTests
{
    public static class Mock
    {
        private static int GetRandomValue()
        {
            var randomNumber = new Random().Next(0, 50);
            return randomNumber;
        }

        public static string Paragraph => MockDataArrays.Contents()[GetRandomValue()];
        public static string Title => MockDataArrays.Titles()[GetRandomValue()];
        public static string Slogan => MockDataArrays.Slogans()[GetRandomValue()];
        public static string CatchPhrase => MockDataArrays.CatchPhrases()[GetRandomValue()];
        public static string Buzzword => MockDataArrays.Buzzwords()[GetRandomValue()];

        public static string[] TagWordsArray()
        {
            var r = new Random();
            var count = r.Next(1, 4);
            var items = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var next = r.Next(0, 50);
                items.Add(MockDataArrays.TagWords()[next]);
            }

            return items.ToArray();
        } 
    }

    public static class MockDataArrays
    {
        public static string[] Contents()
        {
            return new[]
            {
                "Proin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.\n\nAenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\n\nCurabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.\n\nPhasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.",
                "Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.\n\nPraesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.",
                "In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.",
                "Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.\n\nQuisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.",
                "Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.\n\nMorbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.\n\nFusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.",
                "Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.",
                "Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.",
                "Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.",
                "In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.",
                "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.",
                "Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\n\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.",
                "In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.",
                "Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.\n\nNullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.\n\nIn quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.\n\nMaecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.",
                "Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.\n\nMorbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.",
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.",
                "Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.\n\nCras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.",
                "Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.\n\nMorbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.",
                "Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.\n\nQuisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.\n\nPhasellus in felis. Donec semper sapien a libero. Nam dui.",
                "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.\n\nMaecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.",
                "In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo.\n\nAliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.\n\nSed ante. Vivamus tortor. Duis mattis egestas metus.",
                "Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.",
                "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.\n\nPraesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.\n\nCras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                "Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.",
                "Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.",
                "In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.\n\nMaecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.\n\nCurabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.",
                "Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.",
                "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.\n\nDuis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.\n\nDonec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.",
                "Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.",
                "Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.\n\nIn congue. Etiam justo. Etiam pretium iaculis justo.",
                "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.\n\nMaecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.\n\nNullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.",
                "Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.\n\nNam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.\n\nCurabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.",
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.",
                "Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.\n\nCurabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.\n\nInteger tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.",
                "Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\n\nCurabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.\n\nPhasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.",
                "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.\n\nCras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.\n\nProin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.\n\nAenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.",
                "Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.\n\nQuisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.",
                "Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.\n\nDuis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.",
                "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.\n\nInteger tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.",
                "Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.\n\nCurabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.\n\nInteger tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.",
                "Proin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.\n\nAenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\n\nCurabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.\n\nPhasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.",
                "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.\n\nInteger tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.",
                "Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.\n\nPraesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.",
                "In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.\n\nNulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.",
                "Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.",
                "Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.\n\nDonec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.\n\nDuis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.\n\nIn sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.",
                "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.",
                "Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.\n\nNam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.",
                "Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.\n\nDuis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.",
                "Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.\n\nDuis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.\n\nIn sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.",
                "Sed ante. Vivamus tortor. Duis mattis egestas metus.\n\nAenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh."
            };
        }

        public static string[] TagWords()
        {
            return new[]
            {
                "Vi", "Cyber Defense", "Agile Project Management", "Air Freight", "NCAA Compliance", "SVT",
                "Metro Ethernet", "ML", "Oracle RDC", "DH+", "Project Estimation", "SAP MDM", "EASA", "Rhythm Guitar",
                "CNG", "Novels", "Performance Appraisal", "Tubing", "VMD", "Feature Articles", "Visio",
                "Ulead VideoStudio", "User Interface", "Fixed Income", "Warranty", "EOQ", "Dog Training", "RT-PCR",
                "Gnuplot", "Ukrainian", "OBIEE", "Recruiting", "Easytrieve", "Fixed Income", "RDP", "Jitter", "JTAG",
                "Music Production", "Jing", "Piloting", "Online Advertising", "Metro Ethernet", "Grievances",
                "Qualitative Research", "Qt Creator", "AHP", "Slope Stability Analysis", "RMI", "Boilers", "Online Help"
            };
        }

        public static string[] Buzzwords()
        {
            return new[]
            {
                "Frame", "24 hour", "Extended", "Advanced", "Fundamental", "Enterprise-wide", "Local", "Automated",
                "Empowering", "Leading edge", "Profit-focused", "Seamless", "Reactive", "Assimilated", "Uniform",
                "Impactful", "Reverse-engineered", "Polarised", "Contingency", "Multi-tasking", "Bandwidth-monitored",
                "Solution-oriented", "Even-keeled", "Face to face", "Flexibility", "Coherent", "Forecast",
                "Implementation", "Intermediate", "Pricing structure", "Extranet", "Content-based",
                "Contextually-based", "Fault-tolerant", "Challenge", "Organized", "Customizable", "Coherent",
                "Groupware", "Multi-lateral", "Hybrid", "Customer loyalty", "Migration", "Team-oriented", "Policy",
                "Organized", "Eco-centric", "Contingency", "Operative", "User-facing"
            };
        }

        public static string[] Titles()
        {
            return new[]
            {
                "Universitas Negeri Manado",
                "Urumqi Vocational University",
                "Fachhochschulstudiengänge der Wiener Wirtschaft",
                "College of New Caledonia",
                "Universidad Mayor de San Andrés",
                "Krirk University",
                "Universidad Amazonica de Pando",
                "Ross University, School of Medicine",
                "University of Ulster",
                "Kaunas Medical Academy",
                "Le Moyne-Owen College",
                "Perm State Academy of Agriculture",
                "University of Auckland",
                "Obirin University",
                "The Tulane University of New Orleans",
                "Houghton College",
                "Hogeschool voor Wetenschap en Kunst (VLEKHO), Brussel",
                "Iranian Academy of Persian Language and Literature",
                "Universidad Nacional San Luis Gonzaga",
                "Damietta University",
                "Université François Rabelais de Tours",
                "Institut National des Télécommunications",
                "Universidad Autónoma de Aguascalientes",
                "Taipei Medical College",
                "Harbin Institute of Technology",
                "Guangzhou Normal University",
                "Université Omar Bongo",
                "Power and Water Institute of Technology",
                "Universidade do Extremo Sul Catarinense",
                "Macalester College",
                "Dominican College of Philosophy and Theology",
                "Heisei International University",
                "Institute of Textile Technology",
                "SRH University of Applied Sciences",
                "National American University, Albuquerque",
                "Alfred University",
                "Université des Antilles et de la Guyane",
                "Universidad del Pacifico",
                "Greenheart Medical School",
                "Selcuk University",
                "Fachhochschule für Technik und Wirtschaft Berlin",
                "Institut Supérieur de Commerce et d'Administration des Entreprises",
                "University of the Visual & Performing Arts",
                "Sendai University",
                "National Taiwan Normal University",
                "Reed College",
                "Southern Illinois University at Carbondale",
                "Chonbuk Sanup University of Technology (Howon University)",
                "Manhattanville College",
                "Université d'Alger"
            };
        }

        public static string[] Slogans()
        {
            return new[]
            {
                "Implement dynamic paradigms", "Reinvent B2B systems", "Empower value-added metrics",
                "Engineer viral e-commerce", "Generate magnetic action-items", "Streamline value-added bandwidth",
                "Strategize next-generation communities", "Implement interactive architectures",
                "Incentivize best-of-breed action-items", "Redefine bricks-and-clicks channels",
                "Enable dot-com initiatives", "Drive best-of-breed synergies", "Deploy B2C architectures",
                "Repurpose killer web-readiness", "Incubate visionary metrics", "Empower one-to-one initiatives",
                "Repurpose cutting-edge users", "Embrace efficient synergies", "Deploy world-class infomediaries",
                "Orchestrate 24/365 networks", "Revolutionize enterprise markets", "Mesh cross-media architectures",
                "Cultivate compelling channels", "Whiteboard next-generation users", "Exploit innovative partnerships",
                "Exploit leading-edge applications", "Facilitate user-centric infrastructures",
                "Optimize intuitive schemas", "Generate world-class experiences", "Recontextualize vertical niches",
                "Expedite strategic synergies", "Synergize one-to-one convergence",
                "Reintermediate cross-media eyeballs", "Leverage cross-platform communities",
                "Benchmark granular functionalities", "Whiteboard 24/365 niches", "Implement back-end deliverables",
                "Architect user-centric portals", "Strategize bleeding-edge schemas", "Seize transparent methodologies",
                "Scale killer methodologies", "Implement back-end e-markets", "Transition back-end infomediaries",
                "Maximize web-enabled content", "Deploy seamless portals", "Target best-of-breed portals",
                "Leverage efficient experiences", "Harness ubiquitous experiences",
                "Revolutionize compelling e-markets", "Incubate transparent infrastructures"
            };
        }

        public static string[] CatchPhrases()
        {
            return new[]
            {
                "Business-focused bottom-line infrastructure",
                "Decentralized non-volatile success",
                "Ergonomic executive flexibility",
                "Stand-alone stable groupware",
                "Assimilated context-sensitive success",
                "Assimilated fault-tolerant knowledge user",
                "Ergonomic system-worthy throughput",
                "Object-based dynamic software",
                "Object-based empowering hierarchy",
                "Profit-focused hybrid methodology",
                "Self-enabling value-added installation",
                "Vision-oriented discrete website",
                "Synergistic grid-enabled concept",
                "Managed intangible process improvement",
                "Upgradable leading edge hardware",
                "Decentralized modular secured line",
                "Compatible cohesive access",
                "Grass-roots needs-based website",
                "Advanced eco-centric pricing structure",
                "Implemented secondary synergy",
                "Total attitude-oriented paradigm",
                "Synergized client-driven benchmark",
                "Team-oriented uniform policy",
                "Implemented interactive collaboration",
                "Proactive eco-centric moratorium",
                "Innovative next generation interface",
                "Self-enabling dynamic database",
                "Managed optimizing collaboration",
                "Multi-lateral stable workforce",
                "Managed methodical alliance",
                "Quality-focused uniform secured line",
                "Advanced dynamic open system",
                "Cloned 3rd generation encryption",
                "Innovative modular access",
                "Business-focused multi-state algorithm",
                "Sharable exuding utilisation",
                "Organized zero tolerance product",
                "Multi-lateral 3rd generation array",
                "Horizontal contextually-based synergy",
                "Down-sized asymmetric database",
                "Distributed value-added policy",
                "Advanced reciprocal help-desk",
                "Re-engineered clear-thinking challenge",
                "Optional analyzing workforce",
                "Polarised interactive standardization",
                "Operative uniform utilisation",
                "Multi-layered high-level array",
                "Mandatory context-sensitive system engine",
                "Focused client-driven infrastructure",
                "Centralized systemic service-desk"
            };
        }
    }
}