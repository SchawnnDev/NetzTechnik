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

def mod(bit_string, where)
	count = 0

	where.each { |x| count += bit_string[x - 1].to_i }
	
	return count % 2

end

bits_length = 8
puts "Please the byte of data you want to encode (7 bits)"
to_encode = gets.chomp

while to_encode.length != 7
	puts "Incorrect byte of data length"
	to_encode = gets.chomp
end

parity_bits = get_parity_bits(bits_length)

parity_bits.each { |x|
	to_encode.insert(x - 1, '_')
}

parity_bits.each { |x|
	positions = get_positions(x, bits_length)
	puts positions
	to_encode[x - 1] = String(mod(to_encode, positions))
}

puts "Encodierter Hamming-Code: " << to_encode