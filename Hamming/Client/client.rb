def get_parity_bits(length)
	parity_bits = []
	curr_val = 0
	
	until 2 ** curr_val > length
		parity_bits << 2 ** curr_val
		curr_val += 1
	end
	
	return parity_bits
	
end

def get_positions(pos, length)
	positions = []
	curr_val = pos
	
	until curr_val > length
	
		for a in 1..pos do
			positions << curr_val
			curr_val += 1
		end
		
		curr_val += pos

	end
	
	return positions

end

def is_even(bit_string, where)
	count = 0

	where.each { |x| count += bit_string[x - 1].to_i }
	
	return count % 2 == 0

end

puts "Please the byte of data you want to encode (8 bits)"
to_encode = "10011010"#gets.chomp

while to_encode.length != 8
puts "Incorrect byte of data length"
to_encode = gets.chomp
end

get_parity_bits(to_encode.length).each { |x|
	even = is_even(to_encode, get_positions(x, to_encode.length))
	puts "x " << String(x) << " is " << (even ? "true" : "false")
	to_encode.insert(x - 1, even ? "0" : "1")
}

puts "Encodierter Hamming-Code: " << to_encode