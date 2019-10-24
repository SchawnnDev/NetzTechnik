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

input_length = 7
output_length = 11

to_encode = ARGV.length == 0 ? "1000001" : ARGV[0].dup

parity_bits = get_parity_bits(input_length + 1)

parity_bits.each { |x| to_encode.insert(x - 1, '_') }

parity_bits.each { |x| to_encode[x - 1] = String(mod(to_encode, get_positions(x, output_length))) }

puts "Encodierter Hamming-Code: " << to_encode
