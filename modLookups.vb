﻿Module modLookups
    Public GOG_Steam As New Dictionary(Of String, String)

    Sub LoadTables()
        With GOG_Steam
            .Add("6", "38450") 'MDK
            .Add("1111208428", "409720") 'BioShock 2 Remastered
            .Add("1207658705", "15700") 'Oddworld: Abe's Oddysee
            .Add("1207658712", "40950") 'Stronghold HD
            .Add("1207658807", "3830") 'Psychonauts
            .Add("1207658924", "20900") 'The Witcher: Enhanced Edition Director's Cut
            .Add("1207658927", "327940") 'Dragonsphere
            .Add("1207658945", "285310") 'Roller Coaster Tycoon: Deluxe
            .Add("1207658957", "285330") 'Roller Coaster Tycoon 2: Triple Thrill Pack
            .Add("1207659020", "35700") 'Trine Enchanted Edition
            .Add("1207659032", "2700") 'Roller Coaster Tycoon 3: Platinum
            .Add("1207659069", "41500") 'Torchlight
            .Add("1207659102", "212680") 'FTL
            .Add("1207659172", "238210") 'System Shock 2
            .Add("1207659221", "25600") 'Eschalon: Book I
            .Add("1207659253", "225260") 'Brutal Legend
            .Add("1207659257", "239350") 'Spelunky
            .Add("1207659593", "245390") 'I Have No Mouth And I Must Scream
            .Add("1207659753", "70300") 'VVVVVV
            .Add("1207659833", "233720") 'Surgeon Simulator
            .Add("1207660064", "238320") 'Outlast
            .Add("1207660413", "234650") 'Shadowrun Returns
            .Add("1207660893", "226840") 'Age of Wonders 3
            .Add("1207660913", "300550") 'Shadowrun: Dragonfall - Director's Cut
            .Add("1207664803", "223830") 'Xenonauts
            .Add("1207666433", "262000") 'Gabriel Knight: Sins of the Father - 20th Anniversary Edition
            .Add("1207666503", "237850") 'Dreamfall Chapters: The Final Cut
            .Add("1207667183", "316790") 'Grim Fandango Remastered
            .Add("1230412827", "423950") 'Deadlight: Director's Cut
            .Add("1269268081", "409710") 'BioShock Remastered
            .Add("1308320804", "367520") 'Hollow Knight
            .Add("1421064427", "304650") 'Sunless Sea
            .Add("1427108887", "359650") 'Star Trek: 25th Anniversary
            .Add("1429089605", "364800") 'Star Trek: Judgment Rites
            .Add("1429170550", "364810") 'Star Trek: Starfleet Academy
            .Add("1429172763", "364820") 'Star Trek: Starfleet Command Gold Edition
            .Add("1429864849", "220200") 'Kerbal Space Program
            .Add("1430740458", "9480") 'Saints Row 2
            .Add("1434021265", "324800") 'Shadow Warrior 2
            .Add("1436866438", "346940") 'Shadowrun Hong Kong - Extended Edition
            .Add("1437564865", "308420") 'Ziggurat
            .Add("1440163405", "38420") 'Fallout Tactics
            .Add("1440166342", "38400") 'Fallout
            .Add("1440166436", "38410") 'Fallout 2
            .Add("1441974651", "233450") 'Prison Architect
            .Add("1457519353", "388880") 'Oxenfree
            .Add("1461061433", "26800") 'Braid
            .Add("1640424747", "124923") 'The Witcher 3: Wild Hunt - Game of the Year Edition
            .Add("1949616134", "47810") 'Dragon Age: Origins - Ultimate Edition
            .Add("2114871440", "244160") 'Homeworld Remastered Collection
            .Add("2115713947", "281610") 'Homeworld: Deserts of Kharak
            .Add("2133872469", "542050") 'Forgotton Anne
        End With
    End Sub
End Module