#perl -w
#start at 12:48
 #
 #HamExamHelper, the little helper to help you pass your ham exams!
 #Copyright (C) 2006 Markus Schulz
 # 
 #This program is free software; you can redistribute it and/or
 #modify it under the terms of the GNU General Public License
 #as published by the Free Software Foundation; either version 2
 #of the License, or (at your option) any later version.
 #
 #This program is distributed in the hope that it will be useful,
 #but WITHOUT ANY WARRANTY; without even the implied warranty of
 #MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 #GNU General Public License for more details.
 #
 #You should have received a copy of the GNU General Public License
 #along with this program; if not, write to the Free Software
 #Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 #
 #
 # Created by Markus Schulz with the help of SharpDevelop and Visual C# express.
 # User: $Author$
 # Date: $LastChangedDate$
 # Rev : $Rev$
 # 
 # ID: $Id$
 #
use strict;
open PINPUT,"<2002Extra.txt";
open POUTPUT,">output.txt";
while(<PINPUT>)
	{
		chomp;
		if (/(E|G)\d[a-zA-Z]\d\d/) {
		print POUTPUT "~~\n$`$&$'\n";
		# If you need these for testing patterns with
		# memories, uncomment them as well
		# print "    And memory one got <$1>\n";
		# print "    And memory two got <$2>\n";
	    } else {
		print POUTPUT $_."\n";
	    }

	}
close POUTPUT;
close PINPUT;